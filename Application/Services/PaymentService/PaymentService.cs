using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Exceptions;
using AutoMapper;
using Domain.Models;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;
        public PaymentService(IAppointmentRepository appointmentRepository, IPaymentRepository paymentRepository,IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }
        public async Task Add(PaymentRequestDTO requestPayment)
        {
            if (requestPayment == null)
            {
                throw new BadRequestException("Payment Information is invalid!");
            }
            var payment = _mapper.Map<Payment>(requestPayment);
            payment.Appointment = await _appointmentRepository.GetAsync(requestPayment.AppointmentId);
            await _paymentRepository.AddAsync(payment);
            if (await _paymentRepository.SaveChangeAsync() is false)
            {
                throw new BadRequestException("Error when adding Payment!");
            }
        }

        public async Task Delete(long Id)
        {
            var payment = await _paymentRepository.GetAsync(Id);
            if (payment == null)
            {
                throw new NotFoundException("Payment not found!");
            }
            _paymentRepository.Delete(payment);
            if (await _paymentRepository.SaveChangeAsync() is false)
            {
                throw new NotFoundException("Error when deleting Payment!");
            }
        }

        public async Task<ICollection<PaymentResponseDTO>> GetAllPayments()
        {
            var payments = await _paymentRepository.GetAllPayments();
            return _mapper.Map<ICollection<PaymentResponseDTO>>(payments);
        }

        public async Task<PaymentResponseDTO> GetPayment(long Id)
        {
            var payment = await _paymentRepository.GetAsync(Id);
            if (payment == null)
            {
                throw new NotFoundException("Payment not found!");
            }
            return _mapper.Map<PaymentResponseDTO>(payment);
        }

        public async Task Update(long id, PaymentRequestDTO requestPayment)
        {
            var payment = await _paymentRepository.GetAsync(id);
            if (payment == null)
            {
                throw new NotFoundException("Payment not found!");
            }
            else
            {
                _paymentRepository.Update(_mapper.Map(requestPayment, payment));
            }
            if (await _paymentRepository.SaveChangeAsync() == false)
            {
                throw new BadRequestException("Error when updating Payment!");
            }
        }
    }
}
