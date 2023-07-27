using Application.DTOs.Request;
using Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.PaymentService
{
    public interface IPaymentService
    {
        public Task<ICollection<PaymentResponseDTO>> GetAllPayments();
        public Task<PaymentResponseDTO> GetPayment(long Id);
        public Task Add(PaymentRequestDTO payment);
        public Task Update(long id, PaymentRequestDTO payment);
        public Task Delete(long Id);
    }
}
