
using AutoMapper;
using BussinessObject.DTO;
using BussinessObject.DTO.Response;
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
        private readonly IMapper _mapper;
        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        [HttpGet]
        //[Authorize(Roles = "Customer")]
        public IActionResult GetCustomers()
        {
            var customers= _mapper.Map<ICollection<CustomerResponseDTO>>(_customerRepository.GetCustomers());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(customers);
        }
    }
}
