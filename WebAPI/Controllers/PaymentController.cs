using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Services.PaymentService;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController:Controller
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpGet]
        //[Authorize(Roles = "Customer")]
        public async Task<ActionResult<ICollection<PaymentResponseDTO>>> GetPayments()
        {
            var payments = await _paymentService.GetAllPayments();
            return Ok(payments);
        }
        [HttpGet("{id}")]
        //[Authorize(Roles = "Customer")]
        public async Task<ActionResult<PaymentResponseDTO>> GetPayment(long id)
        {
            var payment = await _paymentService.GetPayment(id);
            return Ok(payment);
        }
        [HttpPost]
        public async Task<ActionResult> CreateDiscount(PaymentRequestDTO payment)
        {
            await _paymentService.Add(payment);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateService(long id, PaymentRequestDTO payment)
        {
            await _paymentService.Update(id, payment);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDiscount(long id)
        {
            await _paymentService.Delete(id);
            return NoContent();
        }
    }
}
