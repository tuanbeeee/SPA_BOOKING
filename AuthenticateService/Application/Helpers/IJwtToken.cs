using Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public interface IJwtToken
    {
        SignInResponseDTO GenerateJwtToken(string email, string role);
        SignInResponseDTO? VerifyToken(string token);
    }
}
