using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Services.AppointmentDetailService;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentDetailController:Controller
    {
        private readonly IAppointmentDetailService _appointmentDetailService;
        public AppointmentDetailController(IAppointmentDetailService appointmentDetailService)
        {
            _appointmentDetailService = appointmentDetailService;
        }
        [HttpGet]
        public async Task<ActionResult<ICollection<AppointmentDetailResponseDTO>>> GetAppointmentDetails()
        {
            var appointmentDetails = await _appointmentDetailService.GetAllAppointmentDetails();
            return Ok(appointmentDetails);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDetailResponseDTO>> GetAppointmentDetail(long id)
        {
            var appointmentDetail = await _appointmentDetailService.GetAppointmentDetail(id);
            return Ok(appointmentDetail);
        }
        [HttpPost]
        public async Task<ActionResult> CreateDiscount(AppointmentDetailResquestDTO appointmentDetail)
        {
            await _appointmentDetailService.Add(appointmentDetail);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateService(long id, AppointmentDetailResquestDTO appointmentDetail)
        {
            await _appointmentDetailService.Update(id, appointmentDetail);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDiscount(long id)
        {
            await _appointmentDetailService.Delete(id);
            return NoContent();
        }
    }
}
