using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Request
{
    public class StaffRequestDTO
    {
        public string staffName { get; set; }
        public string staffPhone { get; set; }
        public string staffEmail { get; set; }
        public string staffGender { get; set; }
        public long spaId { get; set; }
        public string accountId { get; set; }
    }
}
