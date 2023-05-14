using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Models
{
    public class Staff
    {
        [Key]
        public int staffId { get; set; }
        public int staffName { get; set; }
        public int staffPhone { get; set; }
        public int staffEmail { get; set; }
        public int staffGender { get; set; }
        [ForeignKey("spaId")]
        public Spa spa_Id { get; set; }
        [ForeignKey("accountId")]
        public Account account_Id { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
