using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Services.CustomerService;
using Application.Services.StaffService;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : Controller
    {
        private readonly IStaffService _staffService;

        private readonly IMapper _mapper;
        public StaffController(IStaffService staffService, IMapper mapper)
        {
            _staffService = staffService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<ICollection<StaffResponseDTO>>> GetStaffs()
        {
            var staffs = await _staffService.GetStaffs();
            return Ok(staffs);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<StaffResponseDTO>> GetStaff(long id)
        {
            var staff = await _staffService.GetStaff(id);
            return Ok(staff);
        }

        [HttpPost]
        public async Task<ActionResult> CreateStaff(StaffRequestDTO staff)
        {
            await _staffService.Add(staff);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStaff(long id, StaffRequestDTO staff)
        {
            await _staffService.Update(id, staff);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStaff(long id)
        {

            await _staffService.Delete(id);
            return NoContent();
        }
    }
}
