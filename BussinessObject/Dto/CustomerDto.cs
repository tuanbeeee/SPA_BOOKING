using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Dto
{
    public class CustomerDto
    {
        public long customerId { get; set; }
        public string customerName { get; set; }
        public string customerPhone { get; set; }
        public string customerEmail { get; set; }
        public string customerGender { get; set; }
        public AccountDto Account { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
