using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response
{
    public class StaffResponseDTO
    {
        public long staffId { get; set; }
        public string staffName { get; set; }
        public string staffPhone { get; set; }
        public string staffEmail { get; set; }
        public string staffGender { get; set; }
        public Spa Spa { get; set; }
        public Account Account { get; set; }
    }
}
