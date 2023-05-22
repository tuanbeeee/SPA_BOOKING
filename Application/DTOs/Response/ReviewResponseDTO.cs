using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response
{
    public class ReviewResponseDTO
    {
        public long reviewId { get; set; }
        public int reviewRate { get; set; }
        public string reviewContent { get; set; }
        public Customer Customer { get; set; }
        public Staff Staff { get; set; }
        public Service Service { get; set; }
    }
}
