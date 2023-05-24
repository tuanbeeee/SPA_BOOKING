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
    public class AppointmentDetailRepository : GenericRepository<Appointment_Detail>,IAppointmentDetailRepository
    {
        private readonly SpaBookingDBContext _context;
        public AppointmentDetailRepository(SpaBookingDBContext context):base(context)
        {
            _context = context;
        }

        public async Task<ICollection<Appointment_Detail>> GetAllAppointmentDetails()
        {
            return await _context.AppointmentDetail
                .Include(ad=>ad.Appointment)
                .Include(ad=>ad.Service)
                .ToListAsync();
        }
    }
}
