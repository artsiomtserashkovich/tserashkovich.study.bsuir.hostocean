using AutoMapper;
using Google.Apis.Calendar.v3.Data;
using HostOcean.Domain.Entities;
using HostOcean.Infrastructure.BsuirGroupService;
using HostOcean.Infrastructure.GroupScheduleService;

namespace HostOcean.Infrastructure.MapperProfiles
{
    public class InfrastructureProfile : Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<IISGroup, Group>();
            CreateMap<Event, LaboratoryWork>()
                .ForMember(x => x.Id, conf => conf.MapFrom(src => src.Id))
                .ForMember(x => x.StartDate, conf => conf.MapFrom(src => src.Start.DateTime))
                .ForMember(x => x.Title, conf => conf.MapFrom(src => src.Summary))
                .ForMember(x => x.Description, conf => conf.MapFrom(src => src.Description))
                .ForMember(x => x.LaboratorySubGroup, conf => conf.MapFrom<LaboratoryWorkSubGroupConverter>());
        }

        public class LaboratoryWorkSubGroupConverter : IValueResolver<Event, LaboratoryWork, LaboratorySubGroup>
        {
            public LaboratorySubGroup Resolve(Event source, LaboratoryWork destination, LaboratorySubGroup destMember,
                ResolutionContext context)
            {
                if (destination.Title.Contains(GroupEventTypeConstant.FirstSubgroupLaboratoryWork))
                {
                    return LaboratorySubGroup.First;
                }
                else if (destination.Title.Contains(GroupEventTypeConstant.SecondSubgroupLaboratoryWork))
                {
                    return LaboratorySubGroup.Second;
                }
                else
                {
                    return LaboratorySubGroup.Common;
                }
            }
        }
    }
}