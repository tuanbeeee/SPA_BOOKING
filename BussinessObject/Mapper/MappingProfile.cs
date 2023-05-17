using AutoMapper;
using BussinessObject.Dto;
using BussinessObject.Models;

namespace WebAPI.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<Customer, CustomerDto>(); 
            CreateMap<Account, AccountDto>();
            CreateMap<Review, ReviewDto>();
        }
    }
}
