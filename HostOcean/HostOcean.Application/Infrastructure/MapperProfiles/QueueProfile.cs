using AutoMapper;
using System.Linq;
using HostOcean.Application.Queues.Models;

namespace HostOcean.Application.Infrastructure.MapperProfiles
{
    public class QueueProfile : Profile
    {
        public QueueProfile()
        {
            CreateMap<Domain.Entities.Queue, QueueModel>()
                .ForMember(e => e.UserQueues, _ => _.MapFrom(e => e.UserQueues.OrderBy(q => q.Order)));
        }
    }
}