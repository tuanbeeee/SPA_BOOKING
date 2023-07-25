using Application.DTOs.Request;
using Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.StaffService
{
    public interface IStaffService
    {
        public Task<ICollection<StaffResponseDTO>> GetStaffs();
        public Task<StaffResponseDTO> GetStaff(long Id);
        public Task Add(StaffRequestDTO staff);
        public Task Update(long id, StaffRequestDTO staff);
        public Task Delete(long Id);
    }
}
