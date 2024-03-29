﻿using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Services.SpaService;
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
    public class SpaController : Controller
    {
        private readonly ISpaService _spaService;

        private readonly IMapper _mapper;
        public SpaController(ISpaService spaService, IMapper mapper)
        {
            _spaService = spaService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<ICollection<SpaResponseDTO>>> GetSpas()
        {
            var spa = await _spaService.GetSpas();
            return Ok(spa);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SpaResponseDTO>> GetSpa(long id)
        {
            var spa = await _spaService.GetSpa(id);
            return Ok(spa);
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> CreateSpa(SpaRequestDTO spa)
        {
            await _spaService.Add(spa);
            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> UpdateSpa(long id, SpaRequestDTO spa)
        {
            await _spaService.Update(id, spa);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> DeleteSpa(long id)
        {

            await _spaService.Delete(id);
            return NoContent();
        }
    }
}
