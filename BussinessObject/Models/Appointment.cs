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
        public int appointmentId { get; set; }      
        public DateTime dateCreated { get; set;}
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public int status { get; set; }
        public string note { get; set; }
        [ForeignKey("customerId")]
        public Customer? customer_Id { get; set; }
        [ForeignKey("staffId")]
        public Staff? staff_Id { get; set; }
        [ForeignKey("roomId")]
        public Room? room_Id { get; set; }
        [ForeignKey("paymentId")]
        public Payment? payment_Id { get; set; }
    }
}
