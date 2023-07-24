using Application.DTOs.Request;
using Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AppointmentService
{
    public interface IAppointmentService
    {
        public Task<ICollection<AppointmentResponseDTO>> GetAppointments();
        public Task<AppointmentResponseDTO> GetAppointment(long Id);
        public Task Add(AppointmentRequestDTO appointment);
        public Task Update(long id, AppointmentRequestDTO appointment);
        public Task Delete(long Id);
    }
}
