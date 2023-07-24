using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Request
{
    public class ReviewRequestDTO
    {
        public int reviewRate { get; set; }
        public string reviewContent { get; set; }
        public long customerId { get; set; }
        public long staffId { get; set; }
        public long serviceId { get; set; }
    }
}
