using Application.DTOs.Request;
using Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.DiscountService
{
    public interface IDiscountService
    {
        public Task<ICollection<DiscountResponseDTO>> GetAllDiscount();
        public Task<DiscountResponseDTO> GetDiscount(long Id);
        public Task Add(DiscountRequestDTO discount);
        public Task Update(long id, DiscountRequestDTO discount);
        public Task Delete(long Id);
    }
}
