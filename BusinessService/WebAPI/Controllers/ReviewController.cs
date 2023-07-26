using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Services.ReviewService;
using Application.Services.StaffService;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;

 
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        [HttpGet]
        public async Task<ActionResult<ICollection<ReviewResponseDTO>>> GetReviews()
        {
            var reviews = await _reviewService.GetReviews();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewResponseDTO>> GetReview(long id)
        {
            var review = await _reviewService.GetReview(id);
            return Ok(review);
        }

        [HttpPost]
        [Authorize(Roles = "USER")]
        public async Task<ActionResult> CreateReview(ReviewRequestDTO review)
        {
            await _reviewService.Add(review);
            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "USER")]
        public async Task<ActionResult> UpdateReview(long id, ReviewRequestDTO review)
        {
            await _reviewService.Update(id, review);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReview(long id)
        {

            await _reviewService.Delete(id);
            return NoContent();
        }
    }
}
