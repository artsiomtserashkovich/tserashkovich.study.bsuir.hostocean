using AutoMapper;
using HostOcean.Application.Queues.Models;
using HostOcean.Domain.Entities;

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