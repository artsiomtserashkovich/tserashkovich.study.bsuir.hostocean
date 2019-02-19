using AutoMapper;
using HostOcean.Infrastructure.BsuirGroupService;
using HostOcean.Domain.Entities;

namespace HostOcean.Application.Infrastructure.AutoMapper
{
    public class InfrastructureProfile : Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<IISGroup, Group>();
        }
    }
}