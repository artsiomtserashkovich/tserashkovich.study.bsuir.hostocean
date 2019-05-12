using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HostOcean.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : Controller
    {
        protected readonly IMediator Mediator;
        protected readonly IMapper Mapper;

        protected BaseController(IMediator mediator, IMapper mapper)
        {
            Mediator = mediator;
            Mapper = mapper;
        }
    }
}