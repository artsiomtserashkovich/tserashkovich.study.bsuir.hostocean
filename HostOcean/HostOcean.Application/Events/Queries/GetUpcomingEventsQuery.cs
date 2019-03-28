using AutoMapper;
using HostOcean.Application.Events.Models;
using HostOcean.Application.Interfaces.Persistence;
using HostOcean.Application.LaboratoryWorks.Models;
using HostOcean.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HostOcean.Application.Events.Queries
{
    public class GetUpcomingEventsQuery : IRequest<IEnumerable<LaboratoryWorkEventModel>>
    {
        public string GroupId { get; set; }

        public class GetUpcomingEventsQueryHandler : IRequestHandler<GetUpcomingEventsQuery, IEnumerable<LaboratoryWorkEventModel>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;

            public GetUpcomingEventsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
            }

            public async Task<IEnumerable<LaboratoryWorkEventModel>> Handle(GetUpcomingEventsQuery request, CancellationToken cancellationToken)
            {
                var currentDate = DateTime.Today;
                var upcomingEvents = _unitOfWork.Events.Find(e => e.LaboratoryWork.GroupId == request.GroupId && e.StartDate >= currentDate).ToList();

                var mappedEntites = _mapper.Map<IEnumerable<LaboratoryWorkEvent>, IEnumerable<LaboratoryWorkEventModel>>(upcomingEvents);

                return mappedEntites;
            }
        }
    }
}
