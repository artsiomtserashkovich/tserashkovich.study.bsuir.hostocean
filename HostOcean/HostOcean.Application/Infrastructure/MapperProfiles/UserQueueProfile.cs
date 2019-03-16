using AutoMapper;
using HostOcean.Application.UserQueues.Models;

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