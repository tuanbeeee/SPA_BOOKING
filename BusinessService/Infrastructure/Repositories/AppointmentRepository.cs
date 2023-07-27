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
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        private readonly SpaBookingDBContext _context;
        public AppointmentRepository(SpaBookingDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
