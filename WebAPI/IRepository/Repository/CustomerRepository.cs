using BussinessObject.DBContext;
using BussinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.IRepository.Repository
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly SpaBookingDBContext _context;
        public CustomerRepository(SpaBookingDBContext context)
        {
            _context = context;
        }
        public ICollection<Customer> GetCustomers()
        {
            return _context.Customer
                .Include(c => c.Account)
                .Include(r => r.Reviews)
                .ToList();
        }
    }
}
