using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Exceptions;
using AutoMapper;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AppointmentService
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly IMapper _mapper;

        public AppointmentService(IAppointmentRepository appointmentRepository, ICustomerRepository customerRepository, IStaffRepository staffRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _customerRepository = customerRepository;
            _staffRepository = staffRepository;
            _mapper = mapper;
        }

        public async Task Add(AppointmentRequestDTO requestAppointment)
        {
            if (requestAppointment == null)
            {
                throw new BadRequestException("Appointment Information is invalid!");
            }
            var appointment = _mapper.Map<Appointment>(requestAppointment);
            appointment.Customer = await _customerRepository.GetAsync(requestAppointment.customerID);
            appointment.Staff = await _staffRepository.GetAsync(requestAppointment.staffID);
            await _appointmentRepository.AddAsync(appointment);
            if (await _appointmentRepository.SaveChangeAsync() is false)
            {
                throw new BadRequestException("Error when adding Appointment!");
            }
        }

        public async Task Delete(long Id)
        {
            if (!await _appointmentRepository.IsExist(Id))
            {
                throw new NotFoundException("Appointment not found!");
            }
            _appointmentRepository.Delete(await _appointmentRepository.GetAsync(Id));
            if (await _appointmentRepository.SaveChangeAsync() is false)
            {
                throw new NotFoundException("Error when deleting Appointment!");
            }
        }

        public async Task<AppointmentResponseDTO> GetAppointment(long Id)
        {
            var appointment = await _appointmentRepository.GetAsync(Id);
            if (appointment == null)
            {
                throw new NotFoundException("Appoitment not found!");
            }
            return _mapper.Map<AppointmentResponseDTO>(appointment);
        }

        public async Task<ICollection<AppointmentResponseDTO>> GetAppointments()
        {
            var appointments = await _appointmentRepository.GetAllAsync();
            return _mapper.Map<ICollection<AppointmentResponseDTO>>(appointments);
        }

        public async Task Update(long id, AppointmentRequestDTO appointment)
        {
            var appointmentResquest = await _appointmentRepository.GetAsync(id);
            if (appointment == null)
            {
                throw new NotFoundException("Customer not found!");
            }
            _appointmentRepository.Update(_mapper.Map(appointment, appointmentResquest));
            if (await _appointmentRepository.SaveChangeAsync() == false)
            {
                throw new BadRequestException("Error when updating Customer!");
            }
        }
    }
}
