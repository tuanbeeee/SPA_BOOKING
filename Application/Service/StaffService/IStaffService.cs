using Application.DTOs.Request;
using Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.StaffService
{
    public interface IStaffService
    {
        public Task<ICollection<CustomerResponseDTO>> GetStaffs();
        public Task<CustomerResponseDTO> GetStaff(long Id);
        public Task Add(CustomerRequestDTO staff);
        public Task Update(long id, CustomerRequestDTO staff);
        public Task Delete(long Id);
    }
}
