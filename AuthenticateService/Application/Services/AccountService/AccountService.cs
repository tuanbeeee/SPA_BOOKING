using Application.DTOs.Response;
using Application.Exceptions;
using Application.Helpers;
using AutoMapper;
using Domain.Models;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<Account> _userManager;
        private readonly SignInManager<Account> _signInManager;
        private readonly IJwtToken _jwtToken;
        public AccountService(IAccountRepository accountRepository, IMapper mapper, UserManager<Account> userManager,
            SignInManager<Account> signInManager, IJwtToken jwtToken)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtToken = jwtToken;
        }
        public async Task<AccountResponseDTO>? GetAccountsByEmail(string email)
        {
            var account =  _accountRepository.GetAccountsByEmail(email);
            if (account == null)
            {
                throw new NotFoundException("Account not found!");
            }
            return _mapper.Map<AccountResponseDTO>(account);
        }

        public async Task<SignInResponseDTO> SignInAsync(SignInModel model)
        {
            var result = await _signInManager.PasswordSignInAsync
                (model.Email, model.Password, false, false);
            if (!result.Succeeded)
            {
                return new SignInResponseDTO { Message = "Invalid Email or Password !" };
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            var role = user.Role;
            var resultData = _jwtToken.GenerateJwtToken(model.Email, role);
            return resultData;
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            var user = new Account
            {
                UserName = model.Email,
                Email = model.Email,
                Role = model.Role,
            };
            if (model.ConfirmPassword != model.Password)
            {
                throw new BadRequestException("Confirm password not match!");
            }
            return await _userManager.CreateAsync(user, model.Password);
        }


    }
}
