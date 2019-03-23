using AutoMapper;
using HostOcean.Application.Interfaces.Persistence;
using HostOcean.Application.LaboratoryWorks.Models;
using HostOcean.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HostOcean.Application.LaboratoryWorks.Queries
{
    public class GetUpcomingLabworksQuery : IRequest<IEnumerable<LaboratoryWorkModel>>
    {
        public string GroupId { get; set; }

        public class GetUpcomingLabworksQueryHandler : IRequestHandler<GetUpcomingLabworksQuery, IEnumerable<LaboratoryWorkModel>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;

            public GetUpcomingLabworksQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
            }

            public async Task<IEnumerable<LaboratoryWorkModel>> Handle(GetUpcomingLabworksQuery request, CancellationToken cancellationToken)
            {
                var currentDate = DateTime.Today;
                var upcomingLabs = _unitOfWork.LaboratoryWorks.Find(e => e.Group.Id == request.GroupId && e.StartDate >= currentDate).ToList();

                var mappedEntites = _mapper.Map<IEnumerable<LaboratoryWork>, IEnumerable<LaboratoryWorkModel>>(upcomingLabs);

                return mappedEntites;
            }
        }
    }
}
