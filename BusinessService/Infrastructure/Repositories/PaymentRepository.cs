using Domain.Models;
using Infrastructure.DBContext;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>,IPaymentRepository
    {
        private readonly SpaBookingDBContext _context;
        public PaymentRepository(SpaBookingDBContext context):base(context)
        {
            _context = context;
        }

        public async Task<ICollection<Payment>> GetAllPayments()
        {
            return await _context.Payment.Include(p=>p.Appointment).ToListAsync();
        }
    }
}
