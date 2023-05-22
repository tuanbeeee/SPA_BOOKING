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
        public string PasswordHash { get; set; }
    }
}
