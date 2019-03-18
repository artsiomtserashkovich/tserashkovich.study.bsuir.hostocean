using AutoMapper;
using HostOcean.Application.Queues.Models;

namespace HostOcean.Application.Infrastructure.MapperProfiles
{
    public class QueueProfile : Profile
    {
        public QueueProfile()
        {
            CreateMap<Domain.Entities.Queue, QueueModel>();
        }
    }
}