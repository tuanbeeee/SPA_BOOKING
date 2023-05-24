﻿using Application.DTOs.Request;
using Application.DTOs.Response;
using AutoMapper;
using Domain.Models;

namespace Application.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<Customer, CustomerResponseDTO>(); 
            CreateMap<CustomerRequestDTO, Customer>();
            
            CreateMap<Account, AccountResponseDTO>();
            CreateMap<Review, ReviewResponseDTO>();
            
            CreateMap<Appointment, AppointmentResponseDTO>();
            CreateMap<AppointmentRequestDTO, Appointment>();

            CreateMap<Staff, StaffResponseDTO>();
            CreateMap<StaffRequestDTO, Staff>();

            CreateMap<Spa, SpaResponseDTO>();
            CreateMap<SpaRequestDTO, Spa>();

            CreateMap<Discount, DiscountResponseDTO>();
            CreateMap<DiscountRequestDTO, Discount>();

            CreateMap<Service, ServiceResponseDTO>();
            CreateMap<ServiceRequestDTO, Service>();

            CreateMap<Review, ReviewResponseDTO>();
            CreateMap<ReviewRequestDTO, Review>();
        }
    }
}
