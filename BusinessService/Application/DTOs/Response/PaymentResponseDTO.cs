using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response
{
    public class PaymentResponseDTO
    {
        public long paymentId { get; set; }
        public Double paymentAmount { get; set; }
        public DateTime paymentDate { get; set; }
        public AppointmentResponseDTO Appointment { get; set; }
    }
}
