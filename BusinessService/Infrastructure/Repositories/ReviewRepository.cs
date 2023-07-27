using Domain.Models;
using Infrastructure.DBContext;
using Infrastructure.Repositories.Interfaces;

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
