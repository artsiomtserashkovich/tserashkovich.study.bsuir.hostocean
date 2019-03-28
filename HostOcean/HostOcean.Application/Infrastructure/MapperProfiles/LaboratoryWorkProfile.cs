using AutoMapper;
using HostOcean.Application.LaboratoryWorks.Models;

namespace HostOcean.Application.Infrastructure.MapperProfiles
{
    public class LaboratoryWorkProfile : Profile
    {
        public LaboratoryWorkProfile()
        {
            CreateMap<Domain.Entities.LaboratoryWork, LaboratoryWorkModel>();
        }
    }
}