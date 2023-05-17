using AutoMapper;
using BussinessObject.Dto;
using BussinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;
        private readonly IMapper _mapper;
        public AccountController(IAccountRepository repo, IMapper mapper) {
            accountRepository = repo;
            _mapper = mapper;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel signUpModel)
        {
            var result = await accountRepository.SignUpAsync(signUpModel);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
                return Unauthorized();
            }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInModel signInModel) 
        {
            var result = await accountRepository.SignInAsync(signInModel);

            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }
        [HttpGet]
        //[Authorize(Roles = "Customer")]
        public IActionResult GetCustomers()
        {
            var customers = _mapper.Map<ICollection<AccountDto>>(accountRepository.GetAccount());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(customers);
        }
    }
}
