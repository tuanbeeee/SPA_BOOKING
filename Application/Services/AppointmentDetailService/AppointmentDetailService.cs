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

namespace Application.Services.AppointmentDetailService
{
    public class AppointmentDetailService : IAppointmentDetailService
    {
        private readonly IAppointmentDetailRepository _appointmentDetailRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;
        public AppointmentDetailService(IAppointmentDetailRepository appointmentDetailRepository,
            IServiceRepository serviceRepository,IAppointmentRepository appointmentRepository,IMapper mapper) {
            _appointmentDetailRepository = appointmentDetailRepository;
            _serviceRepository = serviceRepository;
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }
        public async Task Add(AppointmentDetailResquestDTO requestAppointmentDetail)
        {
            if (requestAppointmentDetail == null)
            {
                throw new BadRequestException("Appointment Detail Information is invalid!");
            }
            var appointmentDetail = _mapper.Map<Appointment_Detail>(requestAppointmentDetail);
            appointmentDetail.Appointment = await _appointmentRepository.GetAsync(requestAppointmentDetail.AppointmentId);
            appointmentDetail.Service = await _serviceRepository.GetAsync(requestAppointmentDetail.ServiceId);
            await _appointmentDetailRepository.AddAsync(appointmentDetail);
            if (await _appointmentDetailRepository.SaveChangeAsync() is false)
            {
                throw new BadRequestException("Error when adding Appointment Detail!");
            }
        }

        public async Task Delete(long Id)
        {
            var appointmentDetail = await _appointmentDetailRepository.GetAsync(Id);
            if (appointmentDetail == null)
            {
                throw new NotFoundException("Appointment Detail not found!");
            }
            _appointmentDetailRepository.Delete(appointmentDetail);
            if (await _appointmentDetailRepository.SaveChangeAsync() is false)
            {
                throw new NotFoundException("Error when deleting Appointment Detail!");
            }
        }

        public async Task<ICollection<AppointmentDetailResponseDTO>> GetAllAppointmentDetails()
        {
            var appointmentDetail = await _appointmentDetailRepository.GetAllAppointmentDetails();
            return _mapper.Map<ICollection<AppointmentDetailResponseDTO>>(appointmentDetail);
        }

        public async Task<AppointmentDetailResponseDTO> GetAppointmentDetail(long Id)
        {
            var appointmentDetail = await _appointmentDetailRepository.GetAsync(Id);
            if (appointmentDetail == null)
            {
                throw new NotFoundException("Appointment Detail not found!");
            }
            return _mapper.Map<AppointmentDetailResponseDTO>(appointmentDetail);
        }

        public async Task Update(long id, AppointmentDetailResquestDTO requestAppointmentDetail)
        {
            var appointmentDetail = await _appointmentDetailRepository.GetAsync(id);
            if (appointmentDetail == null)
            {
                throw new NotFoundException("Appointment Detail not found!");
            }
            else
            {
                _appointmentDetailRepository.Update(_mapper.Map(requestAppointmentDetail, appointmentDetail));
            }
            if (await _appointmentDetailRepository.SaveChangeAsync() == false)
            {
                throw new BadRequestException("Error when updating Appointment Detail!");
            }
        }
    }
}
