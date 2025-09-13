using AutoMapper;
using ProductApp.Application.Dtos.UserDtos;
using ProductApp.Infrastructure.Identity;

namespace ProductApp.Application.Mapping;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<RegisterDto, ApplicationUser>()
            .ForMember(x => x.UserName, y => y.MapFrom(z => z.Email));
        CreateMap<ApplicationUser, RegisterDto>();

        CreateMap<LoginDto, ApplicationUser>();
        CreateMap<ApplicationUser, LoginDto>();
    }
}
