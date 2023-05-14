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
        public int reviewId { get; set; }
        public int reviewRate { get; set; }
        public string reviewContent { get; set; }
        [ForeignKey("customerId")]
        public Customer customer_Id { get; set; }
        [ForeignKey("staffId")]
        public Staff staff_Id { get; set; }
        [ForeignKey("serviceId")]
        public Service service_Id { get; set; }
    }
}
