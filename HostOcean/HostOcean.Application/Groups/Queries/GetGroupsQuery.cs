using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HostOcean.Application.Groups.Models;
using HostOcean.Application.Interfaces.Persistence;
using MediatR;

namespace HostOcean.Application.Groups.Queries
{
    public class GetGroupsQuery : IRequest<IEnumerable<GroupModel>>
    {
        public class GetGroupsQueryHandler : IRequestHandler<GetGroupsQuery, IEnumerable<GroupModel>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetGroupsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
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
