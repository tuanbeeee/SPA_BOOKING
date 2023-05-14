using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Models
{
    public class Appointment_Detail
    {
        [Key]
        public int appointmentDetailId { get; set; }
        [ForeignKey("appointmentId")]
        public Appointment appointment_Id { get; set;}
        [ForeignKey("serviceId")]
        public Service service_Id { get; set;}
    }
}
