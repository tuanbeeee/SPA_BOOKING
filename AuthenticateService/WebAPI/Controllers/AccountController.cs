using Application.Services.AccountService;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult> GetAccountById(string id)
        {
            var result = await _accountService.GetAccountById(id)!;
            return Ok(result);
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult> GetAccountByEmail(string email)
        {
            var result = await _accountService.GetAccountByEmail(email)!;
            return Ok(result);
        }
    }
}
