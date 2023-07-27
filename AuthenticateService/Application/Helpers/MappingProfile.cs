﻿
using Application.DTOs.Response;
using AutoMapper;
using Domain.Models;

namespace Application.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<Account, AccountResponseDTO>();
        }
    }
}
