using Application.DTOs.Response;
using Application.Helpers;
using Application.Services.AccountService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.Middleware
{
    public class AuthorizeAdminAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IJwtToken _jwtToken;
        private readonly IAccountService _accountService;
        public AuthorizeAdminAttribute(IJwtToken jwtToken, IAccountService accountService)
        {
            _jwtToken = jwtToken;
            _accountService = accountService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (string.IsNullOrEmpty(token))
            {
                context.Result = new JsonResult(new { message = "UnAuthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }
            var user = _jwtToken.VerifyToken(token);

            if (string.IsNullOrEmpty(user?.Email) || user?.Role?.ToUpper() != "ADMIN")
            {
                // not logged in or not ADMIN role
                context.Result = new JsonResult(new { message = "UnAuthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }

            //Get User
            var userDetail = _accountService.GetAccountsByEmail(user.Email);

            if (userDetail == null)
            {
                // not logged in
                context.Result = new JsonResult(new { message = "UnAuthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }

            //Set context
            context.HttpContext.Items["User"] = new SignInResponseDTO
            {
                Email = user.Email,
                Role = user.Role,

            };
        }
    }
}
