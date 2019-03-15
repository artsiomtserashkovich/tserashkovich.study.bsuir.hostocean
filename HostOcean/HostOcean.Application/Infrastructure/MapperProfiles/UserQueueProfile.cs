using AutoMapper;
using HostOcean.Application.UserQueue.Models;

namespace HostOcean.Application.Infrastructure.MapperProfiles
{
    public class UserQueueProfile : Profile
    {
        public UserQueueProfile()
        {
            CreateMap<Domain.Entities.UserQueue, UserQueueModel>();
        }
    }
}