using BussinessObject.Models;

namespace WebAPI.IRepository
{
    public interface ICustomerRepository
    {
        ICollection<Customer> GetCustomers();
        Customer GetCustomer(long id);
        Customer CreateCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
    }
}
