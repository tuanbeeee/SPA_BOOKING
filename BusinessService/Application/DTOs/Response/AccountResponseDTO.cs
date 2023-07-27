using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response
{
    public class AccountResponseDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public Boolean Status { get; set; }
    }
}
