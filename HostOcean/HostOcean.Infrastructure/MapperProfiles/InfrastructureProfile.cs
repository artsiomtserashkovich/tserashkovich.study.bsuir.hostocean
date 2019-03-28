using AutoMapper;
using Google.Apis.Calendar.v3.Data;
using HostOcean.Domain.Entities;
using HostOcean.Infrastructure.BsuirGroupService;
using HostOcean.Infrastructure.GroupScheduleService;
using System;
using System.Text.RegularExpressions;

namespace HostOcean.Infrastructure.MapperProfiles
{
    public class InfrastructureProfile : Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<IISGroup, Domain.Entities.Group>();
            CreateMap<Event, LaboratoryWorkEvent>()
                .ForMember(x => x.StartDate, conf => conf.MapFrom(src => src.Start.DateTime))
                .ForMember(x => x.RegistrationStartedAt, conf => conf.MapFrom(src => src.Start.DateTime.Value.AddDays(-1)))
                .ForMember(x => x.Location, conf => conf.MapFrom<LaboratoryWorkLocationResolver>())
                .ForMember(x => x.LaboratoryWork, conf => conf.MapFrom<LaboratoryWorkEventResolver>());
        }

        public class LaboratoryWorkEventResolver : IValueResolver<Event, LaboratoryWorkEvent, LaboratoryWork>
        {
            private LaboratorySubGroup GetLaboratorySubGroup(Event destination)
            {
                if (destination.Summary.Contains(GroupEventTypeConstant.FirstSubgroupLaboratoryWork))
                {
                    return LaboratorySubGroup.First;
                }
                else if (destination.Summary.Contains(GroupEventTypeConstant.SecondSubgroupLaboratoryWork))
                {
                    return LaboratorySubGroup.Second;
                }
                else
                {
                    return LaboratorySubGroup.Common;
                }
            }

            public LaboratoryWork Resolve(Event source, LaboratoryWorkEvent destination, LaboratoryWork destMember, ResolutionContext context)
            {
                var titleResult = new Regex(@"([^?]*\))").Match(source.Summary);
                var lecturerResult = new Regex(@", ([^?]*)\Z").Match(source.Summary);


                destMember = new LaboratoryWork();

                try {
                    destMember.Title = titleResult.Groups[1].Value;
                    destMember.Lecturer = lecturerResult.Groups[1].Value;
                    destMember.LaboratorySubGroup = GetLaboratorySubGroup(source);
                } catch(Exception ex)
                {

                }

                return destMember;
            }
        }

        public class LaboratoryWorkLocationResolver : IValueResolver<Event, LaboratoryWorkEvent, string>
        {
            public string Resolve(Event source, LaboratoryWorkEvent destination, string destMember,
                ResolutionContext context)
            {
                var regEx = new Regex(@"([^?]*\)) ([^ ]*)");
                var result = regEx.Match(source.Summary).Groups[2].Value;

                return result;
            }
        }
    }
}