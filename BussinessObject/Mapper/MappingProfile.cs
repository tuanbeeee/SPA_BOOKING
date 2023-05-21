using AutoMapper;
using BussinessObject.DTO.Request;
using BussinessObject.DTO.Response;
using BussinessObject.Models;

namespace WebAPI.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<Customer, CustomerResponseDTO>(); 
            CreateMap<CustomerRequestDTO, Customer>();
            CreateMap<Account, AccountResponseDTO>();
            CreateMap<Review, ReviewResponseDTO>();
        }
    }
}
