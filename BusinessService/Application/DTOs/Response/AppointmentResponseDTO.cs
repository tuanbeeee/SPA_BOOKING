using Domain.Models;
using Domain.Models.Emun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response
{
    public class AppointmentResponseDTO
    {
        public long appointmentId { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public AppointmentStatus status { get; set; }
        public string note { get; set; }
        public Customer? Customer { get; set; }
        public Staff? Staff { get; set; }
        public Payment? Payment { get; set; }
    }
}
