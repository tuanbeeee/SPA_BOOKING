using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Models
{
    public class Payment
    {
        [Key]
        public int paymentId { get; set; }
        public int paymentAmount { get; set; }
        public DateTime paymentDate { get; set; }
        [ForeignKey("appointmentId")]
        public Appointment appointment_Id { get; set; }
    }
}
