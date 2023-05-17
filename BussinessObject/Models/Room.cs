using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Models
{
    public class Room
    {
        [Key]
        public long roomId { get; set; }
        public string roomName { get; set; }
        public string roomDescription { get; set; }
        public int roomStatus { get; set; }
        public Spa Spa { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
