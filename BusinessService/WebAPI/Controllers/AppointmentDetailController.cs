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
        private readonly ILogger<AppointmentDetailController> _logger;
        public AppointmentDetailController(IAppointmentDetailService appointmentDetailService, ILogger<AppointmentDetailController> logger)
        {
            _appointmentDetailService = appointmentDetailService;
            _logger = logger;
        }
        [HttpGet]
        //[Authorize(Roles = "Customer")]
        public async Task<ActionResult<ICollection<AppointmentDetailResponseDTO>>> GetAppointmentDetails()
        {
            _logger.LogInformation("This is a sample log message.");
            var appointmentDetails = await _appointmentDetailService.GetAllAppointmentDetails();
            return Ok(appointmentDetails);
        }
        [HttpGet("{id}")]
        //[Authorize(Roles = "Customer")]
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
