using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response
{
    public class ServiceResponseDTO
    {
        public long serviceId { get; set; }
        public string serviceName { get; set; }
        public string serviceDuration { get; set; }
        public Double servicePrice { get; set; }
        public SpaResponseDTO Spa { get; set; }
        public ICollection<Appointment_Detail> Appointment_Details { get; set; }
        public ICollection<DiscountResponseDTO> Discounts { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
