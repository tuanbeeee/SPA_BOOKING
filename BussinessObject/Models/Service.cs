﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Models
{
    public class Service
    {
        [Key]
        public long serviceId { get; set; }
        public string serviceName { get; set; }
        public string serviceDuration { get; set; }
        public Double servicePrice { get; set; }
        public ICollection<Appointment_Detail> appointmentDetails { get; set; }
        public ICollection<Discount> Discounts { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
