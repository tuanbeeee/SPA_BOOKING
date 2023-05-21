
using AutoMapper;
using BussinessObject.DTO.Request;
using BussinessObject.DTO.Response;
using BussinessObject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.IRepository;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController:Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerRepository customerRepository,IAccountRepository accountRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _accountRepository = accountRepository;
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
        [HttpGet("{id}")]
        //[Authorize(Roles = "Customer")]
        public IActionResult GetCustomer(long id)
        {
            var customer = _mapper.Map<CustomerResponseDTO>(_customerRepository.GetCustomer(id));
            if(customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPost]
        public IActionResult CreateCustomer(CustomerRequestDTO customer)
        {
            var cus=_mapper.Map<Customer>(customer);
            cus.Account = _accountRepository.GetAccountsByID(customer.account_Id);
            var responseCus=_mapper.Map<CustomerResponseDTO>(_customerRepository.CreateCustomer(cus));
            return Ok(responseCus);         
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(long id,CustomerRequestDTO customer) {
            var isExist = _customerRepository.isExist(id);
            if(isExist == false)
            {
                return NotFound();
            }
            else
            {
                var reqCus = _mapper.Map<Customer>(customer);
                reqCus.customerId = id;
                var responseCus = _mapper.Map<CustomerResponseDTO>(_customerRepository.UpdateCustomer(reqCus));
                return Ok(responseCus);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(long id) {
            
            if (!_customerRepository.isExist(id))
            {
                return NotFound();
            }
            else
            {
                var cus=_customerRepository.GetCustomer(id);
               _customerRepository.DeleteCustomer(cus);
                return Ok();
            }
        }
    }
}
