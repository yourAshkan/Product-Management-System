using AutoMapper;
using NadinSoftTask.Application.Dtos.UserDtos;
using NadinSoftTask.Domain.Users.Entities;

namespace NadinSoftTask.Application.Mapping;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, RegisterDto>();
        CreateMap<User, LoginDto>();
    }
}
