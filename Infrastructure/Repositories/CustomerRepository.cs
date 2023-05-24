
using Domain;
using Domain.IRepository;
using Domain.Models;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly SpaBookingDBContext _context;
        public CustomerRepository(SpaBookingDBContext context) : base(context) 
            {
                _context = context;
            }

        public async Task<ICollection<Customer>> GetAllCustomers()
        {
            var customers = await _context.Customer.Include(c=>c.Account).ToListAsync();
            return customers;
        }
    }
}
