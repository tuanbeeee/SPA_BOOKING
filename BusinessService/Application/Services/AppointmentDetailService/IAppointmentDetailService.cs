using Application.DTOs.Request;
using Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AppointmentDetailService
{
    public interface IAppointmentDetailService
    {
        public Task<ICollection<AppointmentDetailResponseDTO>> GetAllAppointmentDetails();
        public Task<AppointmentDetailResponseDTO> GetAppointmentDetail(long Id);
        public Task Add(AppointmentDetailResquestDTO appointmentDetail);
        public Task Update(long id, AppointmentDetailResquestDTO appointmentDetail);
        public Task Delete(long Id);
    }
}
