using Domain.Models;

namespace Infrastructure.Repositories.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        public Task<ICollection<Customer>> GetAllCustomers();
    }
}
