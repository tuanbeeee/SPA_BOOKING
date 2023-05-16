using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Models
{
    public class Account : IdentityUser
    {
        public int Status { get; set; }
        public string Role { get; set; }
        public Staff? staff_Id { get; set; }
        public Customer? customer_Id { get; set; }
    }
}
