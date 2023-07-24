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

namespace Application.Services.ServiceService
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly ISpaRepository _spaRepository;
        private readonly IMapper _mapper;
        public ServiceService(IServiceRepository serviceRepository,ISpaRepository spaRepository,IMapper mapper) {
            _mapper = mapper;
            _serviceRepository = serviceRepository;
            _spaRepository = spaRepository; 
        }

        public async Task Add(ServiceRequestDTO requestService)
        {
            if (requestService == null)
            {
                throw new BadRequestException("Service Information is invalid!");
            }
            var service = _mapper.Map<Service>(requestService);
            service.Spa = await _spaRepository.GetAsync(requestService.spaId);
            await _serviceRepository.AddAsync(service);
            if (await _serviceRepository.SaveChangeAsync() is false)
            {
                throw new BadRequestException("Error when adding Service!");
            }
        }

        public async Task Delete(long Id)
        {
            var service = await _serviceRepository.GetAsync(Id);
            if (service == null)
            {
                throw new NotFoundException("Service not found!");
            }
            _serviceRepository.Delete(service);
            if (await _serviceRepository.SaveChangeAsync() is false)
            {
                throw new NotFoundException("Error when deleting Service!");
            }
        }

        public async Task<ICollection<ServiceResponseDTO>> GetAllServices()
        {
            var services = await _serviceRepository.GetAllServices();
            return _mapper.Map<ICollection<ServiceResponseDTO>>(services);
        }

        public async Task<ServiceResponseDTO> GetService(long Id)
        {
            var service = await _serviceRepository.GetAsync(Id);
            if (service == null)
            {
                throw new NotFoundException("Service not found!");
            }
            return _mapper.Map<ServiceResponseDTO>(service);
        }

        public async Task Update(long id, ServiceRequestDTO requestService)
        {
            var service = await _serviceRepository.GetAsync(id);
            if (service == null)
            {
                throw new NotFoundException("Service not found!");
            }
            else
            {
                _serviceRepository.Update(_mapper.Map(requestService, service));
            }
            if (await _serviceRepository.SaveChangeAsync() == false)
            {
                throw new BadRequestException("Error when updating Service!");
            }
        }
    }
}
