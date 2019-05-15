using AutoMapper;
using HostOcean.Application.Requests.Models;
using HostOcean.Domain.Entities;

namespace HostOcean.Application.Infrastructure.MapperProfiles
{
    public class RequestsProfile : Profile
    {
        public RequestsProfile()
        {
            CreateMap<Request, RequestModel>();
        }
    }
}
