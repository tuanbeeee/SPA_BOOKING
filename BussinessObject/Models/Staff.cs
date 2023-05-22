using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Staff
    {
        [Key]
        public long staffId { get; set; }
        public string staffName { get; set; }
        public string staffPhone { get; set; }
        public string staffEmail { get; set; }
        public string staffGender { get; set; }
        public Spa Spa { get; set; }
        [ForeignKey("accountId")]
        public Account Account { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
