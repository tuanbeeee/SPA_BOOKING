using Application.Helpers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.Middleware
{
    public class AuthorizeAdminAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IJwtToken _jwtToken;
        public AuthorizeAdminAttribute(IJwtToken jwtToken)
        {
            _jwtToken = jwtToken;
        }
    }
}
