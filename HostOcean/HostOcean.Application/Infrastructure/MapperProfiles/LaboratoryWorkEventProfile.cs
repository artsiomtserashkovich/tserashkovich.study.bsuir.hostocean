using AutoMapper;
using HostOcean.Application.Events.Models;
using HostOcean.Domain.Entities;

namespace HostOcean.Application.Infrastructure.MapperProfiles
{
    public class LaboratoryWorkEventProfile : Profile
    {
        public LaboratoryWorkEventProfile()
        {
            CreateMap<LaboratoryWorkEvent, LaboratoryWorkEventModel>();
        }
    }
}
