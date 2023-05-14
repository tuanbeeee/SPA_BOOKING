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
        public Customer? customer_Id { get; set; }
        public Staff? staff_Id { get; set; }
        public Room? room_Id { get; set; }
        public Payment? payment_Id { get; set; }
    }
}
