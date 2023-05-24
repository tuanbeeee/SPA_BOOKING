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
    public class ServiceRepository : GenericRepository<Service>,IServiceRepository
    {
        private readonly SpaBookingDBContext _context;
        public ServiceRepository(SpaBookingDBContext context):base(context) 
        {
            _context = context;
        }

        public async Task<ICollection<Service>> GetAllServices()
        {
            return await _context.Service
                .Include(s => s.Discounts)
                .Include(s=>s.Spa)
                .ToListAsync();
        }
    }
}
