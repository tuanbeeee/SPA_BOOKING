using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Review
    {
        [Key]
        public long reviewId { get; set; }
        public int reviewRate { get; set; }
        public string reviewContent { get; set; }
        public Customer? Customer { get; set; }
        public Staff? Staff { get; set; }
        public Service? Service { get; set; }
    }
}
