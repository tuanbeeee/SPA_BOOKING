using BussinessObject.Models;

namespace WebAPI.IRepository
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
    }
}
