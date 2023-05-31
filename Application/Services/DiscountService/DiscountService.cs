using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Exceptions;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.DiscountService
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;
        public DiscountService(IDiscountRepository discountRepository,IServiceRepository serviceRepository,IMapper mapper) {
            _discountRepository = discountRepository;
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }
        public async Task Add(DiscountRequestDTO requestDiscount)
        {
            if (requestDiscount is null)
            {
                throw new BadRequestException("Discount Information is invalid!");
            }
            var discount= _mapper.Map<Discount>(requestDiscount);
            discount.Service = await _serviceRepository.GetAsync(requestDiscount.serviceID);
            await _discountRepository.AddAsync(discount);
            if (await _discountRepository.SaveChangeAsync() is false)
            {
                throw new BadRequestException("Error when adding Discount!");
            }
        }

        public async Task Delete(long Id)
        {
            var discount=await _discountRepository.GetAsync(Id);
            if (discount == null)
            {
                throw new NotFoundException("Discount not found!");
            }
            _discountRepository.Delete(discount);
            if (await _discountRepository.SaveChangeAsync() is false)
            {
                throw new NotFoundException("Error when deleting Discount!");
            }
        }

        public async Task<ICollection<DiscountResponseDTO>> GetAllDiscount()
        {
            var discounts = await _discountRepository.GetAllDiscounts();
            return _mapper.Map<ICollection<DiscountResponseDTO>>(discounts);
        }

        public async Task<DiscountResponseDTO> GetDiscount(long Id)
        {
            var discount = await _discountRepository.GetAsync(Id);
            if (discount == null)
            {
                throw new NotFoundException("Discount not found!");
            }
            return _mapper.Map<DiscountResponseDTO>(discount);
        }

        public async Task Update(long id, DiscountRequestDTO requestDiscount)
        {
            var discount = await _discountRepository.GetAsync(id);
            if (discount == null)
            {
                throw new NotFoundException("Discount not found!");
            }
            else
            {
                _discountRepository.Update(_mapper.Map(requestDiscount, discount));
            }
            if (await _discountRepository.SaveChangeAsync() == false)
            {
                throw new BadRequestException("Error when updating Discount!");
            }
        }
    }
}
