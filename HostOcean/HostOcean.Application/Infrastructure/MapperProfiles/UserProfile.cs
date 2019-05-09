using AutoMapper;
using HostOcean.Application.Users.Commands.UpdateUser;
using HostOcean.Application.Users.Models;
using HostOcean.Domain.Entities;

namespace HostOcean.Application.Infrastructure.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UpdateUserCommand, User>()
                .ForMember(entity => entity.Id, _ => _.Ignore())
                .ForMember(entity => entity.Group, _ => _.Ignore())
                .ForMember(entity => entity.GroupId, _ => _.Ignore());

        }
    }
}