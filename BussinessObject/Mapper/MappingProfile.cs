using AutoMapper;
using BussinessObject.DTO.Response;
using BussinessObject.Models;

namespace WebAPI.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<Customer, CustomerDto>(); 
            CreateMap<Account, AccountResponseDTO>();
            CreateMap<Review, ReviewResponseDTO>();
        }
    }
}
