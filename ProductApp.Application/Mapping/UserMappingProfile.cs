using AutoMapper;
using ProductApp.Application.Dtos.UserDtos;
using ProductApp.Domain.Users.Entities;

namespace ProductApp.Application.Mapping;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<RegisterDto, User>()
            .ForMember(x => x.UserName, y => y.MapFrom(z => z.Email));
        CreateMap<User, RegisterDto>();

        CreateMap<LoginDto, User>();
        CreateMap<User, LoginDto>();
    }
}