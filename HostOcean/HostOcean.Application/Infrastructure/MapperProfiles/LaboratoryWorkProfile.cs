using AutoMapper;
using HostOcean.Application.LaboratoryWorks.Models;

namespace HostOcean.Application.Infrastructure.MapperProfiles
{
    public class LaboratoryWorkProfile : Profile
    {
        public LaboratoryWorkProfile()
        {
            CreateMap<Domain.Entities.LaboratoryWork, LaboratoryWorkModel>()
                .ForMember(model => model.QueueId, _ => _.MapFrom(e => e.Queue.Id));
        }
    }
}