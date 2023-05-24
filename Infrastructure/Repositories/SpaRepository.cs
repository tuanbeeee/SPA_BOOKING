using Domain.Interfaces;
using Domain.Models;
using Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SpaRepository : GenericRepository<Spa>, ISpaRepository
    {
        private readonly SpaBookingDBContext _context;
        public SpaRepository(SpaBookingDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
