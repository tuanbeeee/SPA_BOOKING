using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response
{
    public class SpaResponseDTO
    {
        public long spaId { get; set; }
        public string spaName { get; set; }
        public string spaAddress { get; set; }
        public string spaPhone { get; set; }
        public string spaEmail { get; set; }
        public string spaDescription { get; set; }
    }
}
