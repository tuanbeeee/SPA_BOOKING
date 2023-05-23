using Application.DTOs.Request;
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
        }
    }
}
