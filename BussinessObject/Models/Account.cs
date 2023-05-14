using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Models
{
    public class Account
    {
        [Key]
        public int accountId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int status { get; set; }
        [ForeignKey("staffId")]
        public Staff? staff_Id { get; set; }
        [ForeignKey("customerId")]
        public Customer? customer_Id { get; set; }
    }
}
