using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Models
{
    public class Appointment
    {
        [Key]
        public long appointmentId { get; set; }      
        public DateTime dateCreated { get; set;}
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public int status { get; set; }
        public string note { get; set; }
        public Customer? Customer { get; set; }
        public Staff? Staff { get; set; }
        public Payment? Payment { get; set; }
        public ICollection<Appointment_Detail> Appointment_Details { get; set; }
    }
}
