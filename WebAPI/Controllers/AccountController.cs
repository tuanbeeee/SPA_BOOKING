using Application.Services.AccountService;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService) {
            _accountService = accountService;
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult> SignUp(SignUpModel signUpModel)
        {
            var result = await _accountService.SignUpAsync(signUpModel);
                return Ok(result);   
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult> SignIn(SignInModel signInModel) 
        {
            string result=await _accountService.SignInAsync(signInModel);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }
       
    }
}
