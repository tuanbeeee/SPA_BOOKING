using Application.DTOs.Request;
using Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ReviewService
{
    public interface IReviewService
    {
        public Task<ICollection<ReviewResponseDTO>> GetReviews();
        public Task<ReviewResponseDTO> GetReview(long Id);
        public Task Add(ReviewRequestDTO review);
        public Task Update(long id, ReviewRequestDTO review);
        public Task Delete(long Id);
    }
}
