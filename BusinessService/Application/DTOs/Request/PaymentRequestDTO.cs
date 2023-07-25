using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Request
{
    public class PaymentRequestDTO
    {
        public Double paymentAmount { get; set; }
        public DateTime paymentDate { get; set; }
        public int AppointmentId { get; set; }
    }
}
