using AutoMapper;
using HostOcean.Application.LaboratoryWork.Models;

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