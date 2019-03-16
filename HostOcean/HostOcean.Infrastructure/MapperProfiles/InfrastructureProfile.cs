using AutoMapper;
using HostOcean.Infrastructure.BsuirGroupService;

namespace HostOcean.Infrastructure.MapperProfiles
{
    public class InfrastructureProfile : Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<IISGroup, Domain.Entities.Group>();
        }
    }
}