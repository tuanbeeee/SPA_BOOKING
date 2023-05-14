using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Models
{
    public class Discount
    {
        [Key]
        public int discountId { get; set; }
        public int discountCode { get; set; }
        public int discountType { get; set; }
        public int discountAmount { get; set; }
        public DateTime expireDate { get; set; }
        [ForeignKey("serviceId")]
        public Service service_Id { get; set; }
    }
}
