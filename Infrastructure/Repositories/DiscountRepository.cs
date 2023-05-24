using Domain.Interfaces;
using Domain.Models;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class DiscountRepository : GenericRepository<Discount>, IDiscountRepository
    {
        private readonly SpaBookingDBContext _context;

        public DiscountRepository(SpaBookingDBContext context):base(context) 
        {
            _context = context;
        }

        public async Task<ICollection<Discount>> GetAllDiscounts()
        {
            return await _context.Discount.Include(d => d.Service).ToListAsync();
        }
    }
}
