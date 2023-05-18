using BussinessObject.DBContext;
using BussinessObject.Models;

namespace WebAPI.IRepository.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly SpaBookingDBContext _context;
        public ReviewRepository(SpaBookingDBContext context)
        {
            _context = context;
        }
        public ICollection<Review> GetReviews()
        {
            return _context.Review.ToList();
        }
    }
}
