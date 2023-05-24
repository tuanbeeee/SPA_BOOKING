using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Services.ServiceService;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        [HttpGet]
        //[Authorize(Roles = "Customer")]
        public async Task<ActionResult<ICollection<ServiceResponseDTO>>> GetServices()
        {
            var services = await _serviceService.GetAllServices();
            return Ok(services);
        }
        [HttpGet("{id}")]
        //[Authorize(Roles = "Customer")]
        public async Task<ActionResult<ServiceResponseDTO>> GetService(long id)
        {
            var service = await _serviceService.GetService(id);
            return Ok(service);
        }
        [HttpPost]
        public async Task<ActionResult> CreateDiscount(ServiceRequestDTO service)
        {
            await _serviceService.Add(service);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateService(long id, ServiceRequestDTO service)
        {
            await _serviceService.Update(id, service);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDiscount(long id)
        {
            await _serviceService.Delete(id);
            return NoContent();
        }
    }
}
