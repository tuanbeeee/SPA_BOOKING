using Application.DTOs.Response;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AccountService
{
    public interface IAccountService
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<SignInResponseDTO> SignInAsync(SignInModel model);
        public Task<AccountResponseDTO> GetAccountsByID(string id);
    }
}
