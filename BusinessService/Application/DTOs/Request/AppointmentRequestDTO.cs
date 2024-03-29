﻿
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Request
{
    public class AppointmentRequestDTO
    {
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string note { get; set; }
        public long customerID { get; set; }
        public long staffID { get; set; }
    }
}
