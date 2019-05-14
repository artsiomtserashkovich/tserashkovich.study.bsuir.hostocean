using AutoMapper;
using HostOcean.Application.Events.Models;
using HostOcean.Application.Interfaces.Persistence;
using HostOcean.Application.LaboratoryWorks.Models;
using HostOcean.Application.Requests.Models;
using HostOcean.Application.UserQueues.Models;
using HostOcean.Application.Users.Queries;
using HostOcean.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HostOcean.Application.Requests.Queries
{
    public class GetUsersRequestsQuery : IRequest<IEnumerable<RequestModel>>
    {
        public class GetUpcomingEventsQueryHandler : IRequestHandler<GetUsersRequestsQuery, IEnumerable<RequestModel>>
        {
            private readonly IMapper _mapper;
            private readonly IMediator _mediator;
            private readonly IUnitOfWork _unitOfWork;

            public GetUpcomingEventsQueryHandler(IMapper mapper, IMediator mediator, IUnitOfWork unitOfWork)
            {
                _mapper = mapper;
                _mediator = mediator;
                _unitOfWork = unitOfWork;
            }

            public async Task<IEnumerable<RequestModel>> Handle(GetUsersRequestsQuery query, CancellationToken cancellationToken)
            {
                var currentDate = DateTime.Today;

                var user = await _mediator.Send(new GetCurrentUserQuery());

                var requests = _unitOfWork.Requests.All.Where(r => r.ReceiverUserId == user.Id || r.CreatorUserId == user.Id).OrderByDescending(r => r.CreatedOn).ToList();

                var mappedRequests = _mapper.Map<IEnumerable<Request>, IEnumerable<RequestModel>>(requests);

                return mappedRequests;
            }
        }
    }
}
