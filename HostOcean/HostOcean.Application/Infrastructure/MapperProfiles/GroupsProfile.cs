using AutoMapper;
using HostOcean.Application.Group.Models;

namespace HostOcean.Application.Infrastructure.MapperProfiles
{
    public class GroupsProfile : Profile
    {
        public GroupsProfile()
        {
            CreateMap<Domain.Entities.Group, GroupModel>();
        }
    }
}
