using Application.DTOs.Response;
using Application.Exceptions;
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
        private readonly IMapper _mapper;

        public AccountService(IMapper mapper)
        {
            _mapper = mapper;
        }   
    }
}
