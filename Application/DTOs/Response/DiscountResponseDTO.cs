using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response
{
    public class DiscountResponseDTO
    {
        public long discountId { get; set; }
        public long discountCode { get; set; }
        public int discountType { get; set; }
        public Double discountAmount { get; set; }
        public DateTime expireDate { get; set; }
        public ServiceResponseDTO Service { get; set; }
    }
}
