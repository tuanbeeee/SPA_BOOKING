using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Payment
    {
        [Key]
        public long paymentId { get; set; }
        public Double paymentAmount { get; set; }
        public DateTime paymentDate { get; set; }
        [ForeignKey("appointmentId")]
        public Appointment? Appointment { get; set; }
    }
}
