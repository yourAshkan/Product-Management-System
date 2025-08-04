using AutoMapper;
using ProductApp.Domain.Users.Entities;
using ProductApp.Application.Dtos.UserDtos;

namespace ProductApp.Application.Mapping;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, RegisterDto>();
        CreateMap<User, LoginDto>();
    }
}
