
using AutoMapper;
using BussinessObject.DTO.Response;
using BussinessObject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.IRepository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController:Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _customerMapper;
        public CustomerController(ICustomerRepository customerRepository,IMapper customerMapper)
        {
            _customerRepository = customerRepository;
            _customerMapper = customerMapper;
        }
        [HttpGet]
        //[Authorize]
        public IActionResult GetCustomers()
        {
            var customers=_customerMapper.Map<List<CustomerResponseDTO>>(_customerRepository.GetCustomers());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(customers);
        }
    }
}
