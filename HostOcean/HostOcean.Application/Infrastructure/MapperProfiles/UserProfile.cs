using AutoMapper;
using HostOcean.Application.Users.Models;

namespace HostOcean.Application.Infrastructure.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Domain.Entities.User, UserModel>();
        }
    }
}