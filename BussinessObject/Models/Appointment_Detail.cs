using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Appointment_Detail
    {
        [Key]
        public long appointmentDetailId { get; set; }
        public Appointment? Appointment { get; set;}
        public Service? Service { get; set;}
    }
}
