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

namespace Application.Services.SpaService
{
    public class SpaService : ISpaService
    {
        private readonly ISpaRepository _spaRepository;
        private readonly IMapper _mapper;

        public SpaService(ISpaRepository spaRepository, IMapper mapper)
        {
            _spaRepository = spaRepository;
            _mapper = mapper;
        }

        public async Task Add(SpaRequestDTO spaRequest)
        {
            if (spaRequest == null)
            {
                throw new BadRequestException("Spa Information is invalid!");
            }
            var spa = _mapper.Map<Spa>(spaRequest);
            await _spaRepository.AddAsync(spa);
            if (await _spaRepository.SaveChangeAsync() is false)
            {
                throw new BadRequestException("Error when adding Spa!");
            }
        }

        public async Task Delete(long Id)
        {
            var spa = await _spaRepository.GetAsync(Id);
            if (spa == null)
            {
                throw new NotFoundException("Spa not found!");
            }
            _spaRepository.Delete(spa);
            if (await _spaRepository.SaveChangeAsync() is false)
            {
                throw new NotFoundException("Error when deleting Spa!");
            }
        }

        public async Task<SpaResponseDTO> GetSpa(long Id)
        {
            var spa = await _spaRepository.GetAsync(Id);
            if (spa == null)
            {
                throw new NotFoundException("Spa not found!");
            }
            return _mapper.Map<SpaResponseDTO>(spa);
        }

        public async Task<ICollection<SpaResponseDTO>> GetSpas()
        {
            var spa = await _spaRepository.GetAllAsync();
            return _mapper.Map<ICollection<SpaResponseDTO>>(spa);
        }

        public async Task Update(long id, SpaRequestDTO spaRequest)
        {
            var spa = await _spaRepository.GetAsync(id);
            if (spa == null)
            {
                throw new NotFoundException("Spa not found!");
            }
            else
            {
                _spaRepository.Update(_mapper.Map(spaRequest, spa));
                if (await _spaRepository.SaveChangeAsync() == false)
                {
                    throw new BadRequestException("Error when updating Spa!");
                }
            }
        }
    }
}
