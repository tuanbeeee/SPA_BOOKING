using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Discount
    {
        [Key]
        public long discountId { get; set; }
        public long discountCode { get; set; }
        public int discountType { get; set; }
        public Double discountAmount { get; set; }
        public DateTime expireDate { get; set; }
        public Service? Service { get; set; }
    }
}
