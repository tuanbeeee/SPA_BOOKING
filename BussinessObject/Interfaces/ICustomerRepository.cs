
using Domain;
using Domain.Models;

namespace Domain.IRepository
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        public Task<ICollection<Customer>> GetAllCustomers();
    }
}
