using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Request
{
    public class ServiceRequestDTO
    {
        public string serviceName { get; set; }
        public string serviceDuration { get; set; }
        public Double servicePrice { get; set; }
        public long spaId { get; set; }
        
    }
}
