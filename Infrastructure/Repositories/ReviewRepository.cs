

using Domain.IRepository;
using Domain.Models;
using Infrastructure.DBContext;

namespace Infrastructure.Repositories
{
    public class ReviewRepository : GenericRepository<Review>,IReviewRepository
    {
        private readonly SpaBookingDBContext _context;
        public ReviewRepository(SpaBookingDBContext context):base(context)
        {
            _context = context;
        }

    }
}
