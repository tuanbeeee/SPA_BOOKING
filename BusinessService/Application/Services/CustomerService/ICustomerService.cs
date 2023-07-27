using Application.DTOs.Request;
using Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CustomerService
{
    public interface ICustomerService
    {
        public Task<ICollection<CustomerResponseDTO>> GetCustomers();
        public Task<ICollection<CustomerResponseDTO>> GetAllCustomers();
        public Task<CustomerResponseDTO> GetCustomer(long Id);
        public Task Add(CustomerRequestDTO customer);
        public Task Update(long id, CustomerRequestDTO customer);
        public Task Delete(long Id);

    }
}
