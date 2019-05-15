using AutoMapper;
using HostOcean.Domain.Entities;

namespace HostOcean.Application.Infrastructure.MapperProfiles
{
    public class UserQueueProfile : Profile
    {
        public UserQueueProfile()
        {

            CreateMap<UserQueue, UserQueue>()
                    .ForMember(e => e.User, _ => _.Ignore())
                    .ForMember(e => e.Queue, _ => _.Ignore());
        }
    }
}
