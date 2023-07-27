using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Services.CustomerService;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController:Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public async Task<ActionResult<ICollection<CustomerResponseDTO>>> GetCustomers()
        {
            var customers= await _customerService.GetAllCustomers();   
            return Ok(customers);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerResponseDTO>> GetCustomer(long id)
        {
            var customer = await _customerService.GetCustomer(id);          
            return Ok(customer);
        }
        [HttpPost]
        public async Task<ActionResult> CreateCustomer(CustomerRequestDTO customer)
        {
            await _customerService.Add(customer);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomer(long id,CustomerRequestDTO customer) {
            await _customerService.Update(id, customer);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(long id) {
            
            await _customerService.Delete(id);
            return NoContent();
        }
    }
}
