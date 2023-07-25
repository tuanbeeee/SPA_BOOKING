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

namespace Application.Services.StaffService
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;
        private readonly ISpaRepository _spaRepository;
        private readonly IMapper _mapper;

        public StaffService(IStaffRepository staffRepository, IMapper mapper, ISpaRepository spaRepository)
        {
            _staffRepository = staffRepository;
            _mapper = mapper;
            _spaRepository = spaRepository;

        }

        public async Task Add(StaffRequestDTO staffRequest)
        {
            if (staffRequest == null)
            {
                throw new BadRequestException("Staff Information is invalid!");
            }
            var staff =  _mapper.Map<Staff>(staffRequest);
            //staff.Account = _accountRepository.GetAccountsByID(staffRequest.accountId);
            staff.Spa = await _spaRepository.GetAsync(staffRequest.spaId);
            await _staffRepository.AddAsync(staff);
            if (await _staffRepository.SaveChangeAsync() is false)
            {
                throw new BadRequestException("Error when adding Staff!");
            }
        }

        public async Task Delete(long Id)
        {
            var staff = await _staffRepository.GetAsync(Id);
            if (staff == null)
            {
                throw new NotFoundException("Staff not found!");
            }
            _staffRepository.Delete(staff);
            if (await _staffRepository.SaveChangeAsync() is false)
            {
                throw new NotFoundException("Error when deleting Staff!");
            }
        }

        public async Task<StaffResponseDTO> GetStaff(long Id)
        {
            var staff = await _staffRepository.GetAsync(Id);
            if (staff == null)
            {
                throw new NotFoundException("Staff not found!");
            }
            return _mapper.Map<StaffResponseDTO>(staff);
        }

        public async Task<ICollection<StaffResponseDTO>> GetStaffs()
        {
            var staffs = await _staffRepository.GetAllAsync();
            return _mapper.Map<ICollection<StaffResponseDTO>>(staffs);
        }

        public async Task Update(long id, StaffRequestDTO staffRequest)
        {
            var staff = await _staffRepository.GetAsync(id);
            if (staff == null)
            {
                throw new NotFoundException("Staff not found!");
            }
            else
            {
                _staffRepository.Update(_mapper.Map(staffRequest, staff));
                if (await _staffRepository.SaveChangeAsync() == false)
                {
                    throw new BadRequestException("Error when updating Staff!");
                }
            }
        }
    }
}
