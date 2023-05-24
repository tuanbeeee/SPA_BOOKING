using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Exceptions;
using AutoMapper;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ReviewService
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;

        public ReviewService(IReviewRepository reviewRepository, ICustomerRepository customerRepository, IStaffRepository staffRepository, IServiceRepository serviceRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _staffRepository = staffRepository;
            _serviceRepository = serviceRepository;
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task Add(ReviewRequestDTO reviewRequest)
        {
            if (reviewRequest == null)
            {
                throw new BadRequestException("Review Information is invalid!");
            }
            var review = _mapper.Map<Review>(reviewRequest);
            review.Customer = await _customerRepository.GetAsync(reviewRequest.customerId);
            review.Staff = await _staffRepository.GetAsync(reviewRequest.staffId);
            review.Service = await _serviceRepository.GetAsync(reviewRequest.serviceId);
            await _reviewRepository.AddAsync(review);
            if (await _staffRepository.SaveChangeAsync() is false)
            {
                throw new BadRequestException("Error when adding Review!");
            }
        }

        public async Task Delete(long Id)
        {
            var review = await _reviewRepository.GetAsync(Id);
            if (review == null)
            {
                throw new NotFoundException("Review not found!");
            }
            _reviewRepository.Delete(review);
            if (await _staffRepository.SaveChangeAsync() is false)
            {
                throw new NotFoundException("Error when deleting Review!");
            }
        }

        public async Task<ReviewResponseDTO> GetReview(long Id)
        {
            var review = await _reviewRepository.GetAsync(Id);
            if (review == null)
            {
                throw new NotFoundException("Review not found!");
            }
            return _mapper.Map<ReviewResponseDTO>(review);
        }

        public async Task<ICollection<ReviewResponseDTO>> GetReviews()
        {
            var reviews = await _reviewRepository.GetAllAsync();
            return _mapper.Map<ICollection<ReviewResponseDTO>>(reviews);
        }

        public async Task Update(long id, ReviewRequestDTO reviewRequest)
        {
            var review = await _reviewRepository.GetAsync(id);
            if (review == null)
            {
                throw new NotFoundException("Review not found!");
            }
            else
            {
                _reviewRepository.Update(_mapper.Map(reviewRequest, review));
                if (await _staffRepository.SaveChangeAsync() == false)
                {
                    throw new BadRequestException("Error when updating Review!");
                }
            }
        }
    }
}
