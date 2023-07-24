using Application.Services.AccountService;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AuthenticateController(IAccountService accountService) {
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
            var result=await _accountService.SignInAsync(signInModel);
            if (string.IsNullOrEmpty(result.AccessToken))
            {
                return BadRequest("Invalid Email or Password !");
            }
            return Ok(result);
        }
        
    }
}
