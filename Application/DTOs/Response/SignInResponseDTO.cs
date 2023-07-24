using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response
{
    public class SignInResponseDTO
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public string? Message { get; set; }
    }
}
