
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
            //map customer request into customer
            var cus=_mapper.Map<Customer>(customer);
            //get account by id and map into customer obj
            cus.Account = _accountRepository.GetAccountsByID(customer.account_Id);
            //insert customer and map it into customer reponse
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
                //map customer request into customer
                var reqCus = _mapper.Map<Customer>(customer);
                reqCus.customerId = id;
                //update customer and map it into response customer
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
