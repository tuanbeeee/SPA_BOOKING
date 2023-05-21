using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DTO.Request
{
    public class CustomerRequestDTO
    {     
        public string customerName { get; set; }
        public string customerPhone { get; set; }
        public string customerEmail { get; set; }
        public string customerGender { get; set; }
        public string account_Id { get; set; }
    }
}
