using AutoMapper;
using ProductApp.Application.Dtos.UserDtos;
using ProductApp.Infrastructure.Identity;

namespace ProductApp.Application.Mapping;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<ApplicationUser, RegisterDto>();
        CreateMap<ApplicationUser, LoginDto>();
    }
}
