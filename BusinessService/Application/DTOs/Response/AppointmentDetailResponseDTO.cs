using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response
{
    public class AppointmentDetailResponseDTO
    {
        public long appointmentDetailId { get; set; }
        public Appointment Appointment { get; set; }
        public Service Service { get; set; }
    }
}
