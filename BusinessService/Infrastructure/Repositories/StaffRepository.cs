using Domain.Models;
using Infrastructure.DBContext;
using Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class StaffRepository : GenericRepository<Staff>, IStaffRepository
    {
        private readonly SpaBookingDBContext _context;
        public StaffRepository(SpaBookingDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
