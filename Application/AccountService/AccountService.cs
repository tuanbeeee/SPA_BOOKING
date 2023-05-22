using Application.DTOs.Response;
using Application.Exceptions;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        public AccountService(IAccountRepository accountRepository,IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }
        public async Task<AccountResponseDTO> GetAccountsByID(string id)
        {
            var account = _accountRepository.GetAccountsByID(id);
            if (account == null)
            {
                throw new NotFoundException("Account not found!");
            }
            return _mapper.Map<AccountResponseDTO>(account);
        }

        public async Task<string> SignInAsync(SignInModel model)
        {
            var result = await _accountRepository.SignInAsync(model);

            return result;
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            var result = await _accountRepository.SignUpAsync(model);
            return result;
        }

        
    }
}
