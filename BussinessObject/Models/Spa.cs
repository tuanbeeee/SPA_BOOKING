using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Models
{
    public class Spa
    {
        [Key]
        public long spaId { get; set; }
        public string spaName { get; set; }
        public string spaAddress { get; set; }
        public string spaPhone { get; set; }
        public string spaEmail { get; set; }
        public string spaDescription { get; set; }
        public ICollection<Staff> Staffs { get; set;}
        public ICollection<Service> Services { get; set;}
    }
}
