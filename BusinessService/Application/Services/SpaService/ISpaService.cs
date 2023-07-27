using Application.DTOs.Request;
using Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.SpaService
{
    public interface ISpaService
    {
        public Task<ICollection<SpaResponseDTO>> GetSpas();
        public Task<SpaResponseDTO> GetSpa(long Id);
        public Task Add(SpaRequestDTO spa);
        public Task Update(long id, SpaRequestDTO spa);
        public Task Delete(long Id);
    }
}
