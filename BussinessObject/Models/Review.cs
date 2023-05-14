using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Models
{
    public class Review
    {
        [Key]
        public long reviewId { get; set; }
        public int reviewRate { get; set; }
        public string reviewContent { get; set; }
        public Customer customer_Id { get; set; }
        public Staff staff_Id { get; set; }
        public Service service_Id { get; set; }
    }
}
