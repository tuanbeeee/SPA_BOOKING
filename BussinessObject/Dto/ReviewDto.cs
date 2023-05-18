using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Dto
{
    public class ReviewDto
    {
        public long reviewId { get; set; }
        public int reviewRate { get; set; }
        public string reviewContent { get; set; }
        public Customer Customer { get; set; }
        public Staff Staff { get; set; }
        public Service Service { get; set; }
    }
}
