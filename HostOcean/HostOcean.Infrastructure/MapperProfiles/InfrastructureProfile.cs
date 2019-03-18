using AutoMapper;
using Google.Apis.Calendar.v3.Data;
using HostOcean.Domain.Entities;
using HostOcean.Infrastructure.BsuirGroupService;
using HostOcean.Infrastructure.GroupScheduleService;
using System.Text.RegularExpressions;

namespace HostOcean.Infrastructure.MapperProfiles
{
    public class InfrastructureProfile : Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<IISGroup, Domain.Entities.Group>();
            CreateMap<Event, LaboratoryWork>()
                .ForMember(x => x.Id, conf => conf.MapFrom(src => src.Id))
                .ForMember(x => x.StartDate, conf => conf.MapFrom(src => src.Start.DateTime))
                .ForMember(x => x.Title, conf => conf.MapFrom<LaboratoryWorkTitleResolver>())
                .ForMember(x => x.Location, conf => conf.MapFrom<LaboratoryWorkLocationResolver>())
                .ForMember(x => x.Lecturer, conf => conf.MapFrom<LaboratoryWorkLecturerResolver>())
                .ForMember(x => x.Description, conf => conf.MapFrom(src => src.Description))
                .ForMember(x => x.LaboratorySubGroup, conf => conf.MapFrom<LaboratoryWorkSubGroupConverter>());
        }

        public class LaboratoryWorkTitleResolver : IValueResolver<Event, LaboratoryWork, string>
        {
            public string Resolve(Event source, LaboratoryWork destination, string destMember,
                ResolutionContext context)
            {
                var regEx = new Regex(@"([^?]*\)) ([^ ]*) ([^?]) [^?]*, ([^?]*)");
                var result = regEx.Match(source.Summary).Groups[1].Value;

                return result;
            }
        }

        public class LaboratoryWorkLocationResolver : IValueResolver<Event, LaboratoryWork, string>
        {
            public string Resolve(Event source, LaboratoryWork destination, string destMember,
                ResolutionContext context)
            {
                var regEx = new Regex(@"([^?]*\)) ([^ ]*) ([^?]) [^?]*, ([^?]*)");
                var result = regEx.Match(source.Summary).Groups[2].Value;

                return result;
            }
        }

        public class LaboratoryWorkLecturerResolver : IValueResolver<Event, LaboratoryWork, string>
        {
            public string Resolve(Event source, LaboratoryWork destination, string destMember,
                ResolutionContext context)
            {
                var regEx = new Regex(@"([^?]*\)) ([^ ]*) ([^?]) [^?]*, ([^?]*)");
                var result = regEx.Match(source.Summary).Groups[4].Value;

                return result;
            }
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