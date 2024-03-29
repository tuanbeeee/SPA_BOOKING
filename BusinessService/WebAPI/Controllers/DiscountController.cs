﻿using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Services.DiscountService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ICollection<DiscountResponseDTO>>> GetDiscounts()
        {
            var discounts = await _discountService.GetAllDiscounts();
            return Ok(discounts);
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<DiscountResponseDTO>> GetDiscount(long id)
        {
            var discount = await _discountService.GetDiscount(id);
            return Ok(discount);
        }
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> CreateDiscount(DiscountRequestDTO discount)
        {
            await _discountService.Add(discount);
            return NoContent();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> UpdateDiscount(long id, DiscountRequestDTO discount)
        {
            await _discountService.Update(id, discount);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> DeleteDiscount(long id)
        {

            await _discountService.Delete(id);
            return NoContent();
        }
    }
}
