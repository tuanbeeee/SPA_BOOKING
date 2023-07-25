using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Services.CustomerService;
using Application.Services.AppointmentService;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebAPI.Middleware;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(AuthorizeAdminAttribute))]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        private readonly IMapper _mapper;
        public AppointmentController(IAppointmentService appointmentService, IMapper mapper)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;
        }
        [HttpGet]
        //[Authorize(Roles = "Customer")]
        public async Task<ActionResult<ICollection<AppointmentResponseDTO>>> GetAppointments()
        {
            var appointments = await _appointmentService.GetAppointments();
            return Ok(appointments);
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "Customer")]
        public async Task<ActionResult<AppointmentResponseDTO>> GetAppointment(long id)
        {
            var appointment = await _appointmentService.GetAppointment(id);
            return Ok(appointment);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAppointment(AppointmentRequestDTO appointment)
        {
            await _appointmentService.Add(appointment);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAppointment(long id, AppointmentRequestDTO appointment)
        {
            await _appointmentService.Update(id, appointment);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAppointment(long id)
        {

            await _appointmentService.Delete(id);
            return NoContent();
        }
    }
}
