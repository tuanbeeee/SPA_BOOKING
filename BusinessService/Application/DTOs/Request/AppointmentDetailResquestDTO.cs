using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Request
{
    public class AppointmentDetailResquestDTO
    {
        public long AppointmentId { get; set; }
        public long ServiceId { get; set; }
    }
}
