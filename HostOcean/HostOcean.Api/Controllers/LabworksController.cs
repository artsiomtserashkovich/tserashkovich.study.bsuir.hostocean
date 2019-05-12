using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace HostOcean.Api.Controllers
{
    [Authorize]
    public class LabworksController : BaseController
    {
        public LabworksController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }
    }
}
