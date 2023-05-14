﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace BussinessObject.DBContext
{
    public class SpaBookingDBContext : DbContext
    {
        public SpaBookingDBContext(DbContextOptions<SpaBookingDBContext> options) : base(options) { }
        public DbSet<Account> Account { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Appointment_Detail> AppointmentDetail { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Discount> Discount { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<Spa> Spa { get; set; }
        public DbSet<Staff> Staff { get; set; }
    }
}