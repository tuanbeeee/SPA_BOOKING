using Application.DTOs.Request;
using Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ServiceService
{
    public interface IServiceService
    {
        public Task<ICollection<ServiceResponseDTO>> GetAllServices();
        public Task<ServiceResponseDTO> GetService(long Id);
        public Task Add(ServiceRequestDTO service);
        public Task Update(long id, ServiceRequestDTO service);
        public Task Delete(long Id);
    }
}
