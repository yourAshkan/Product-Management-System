using AutoMapper;
using ProductApp.Domain.Users.Entities;
using ProductApp.Infrastructure.Identity;

namespace ProductApp.Infrastructure
{
    public class InfrastructureUserMappingProfile : Profile
    {
        public InfrastructureUserMappingProfile()
        {
            CreateMap<ApplicationUser, User>().ReverseMap();
        }
    }
}
