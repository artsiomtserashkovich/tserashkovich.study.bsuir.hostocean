using AutoMapper;
using HostOcean.Application.Group.Models;
using HostOcean.Persistence.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HostOcean.Application.Group.Queries
{
    public class GetGroupsQuery : IRequest<IEnumerable<GroupModel>>
    {
        public class GetGroupsQueryHandler : IRequestHandler<GetGroupsQuery, IEnumerable<GroupModel>>
        {
            private readonly IMediator _mediator;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetGroupsQueryHandler(IUnitOfWork unitOfWork, IMediator mediator, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mediator = mediator;
                _mapper = mapper;
            }

            public async Task<IEnumerable<GroupModel>> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
            {
                var groups = _unitOfWork.Groups.All;
                var mappedGroups = _mapper.Map<IEnumerable<Domain.Entities.Group>, IEnumerable<GroupModel>>(groups);

                return mappedGroups;
            }
        }
    }
}
