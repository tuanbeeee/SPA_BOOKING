using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.DBContext
{
    public class SpaBookingDBContext : IdentityDbContext<Account>
    {
        public SpaBookingDBContext()
        {
        }

        public SpaBookingDBContext(DbContextOptions<SpaBookingDBContext> options) : base(options) { }
        public DbSet<Account> Account { get; set; }

        public class DataContextFactory : IDesignTimeDbContextFactory<SpaBookingDBContext>
        {
            public SpaBookingDBContext CreateDbContext(string[] args)
            {
                var configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

                var optionsBuilder = new DbContextOptionsBuilder<SpaBookingDBContext>();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

                return new SpaBookingDBContext(optionsBuilder.Options);
            }
        }
    }
        
}
