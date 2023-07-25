﻿using Application.DTOs.Response;
using Application.Helpers;
using Application.Services.AccountService;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Middleware
{
    public class AuthorizeUserAttribute
    {
        private readonly IJwtToken _jwtToken;
        private readonly IAccountService _accountService;
        public AuthorizeUserAttribute(IJwtToken jwtToken, IAccountService accountService)
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

            if (string.IsNullOrEmpty(user?.Email) || user?.Role?.ToUpper() != "USER")
            {
                // not logged in or not ADMIN role
                context.Result = new JsonResult(new { message = "UnAuthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }

            //Get User
            //var userDetail = _accountService.GetAccountsByEmail(user.Email);
            string userDetail = null;

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
