using AutoMapper;
using HostOcean.Application.LaboratoryWorks.Models;
using HostOcean.Domain.Entities;
using HostOcean.Persistence.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HostOcean.Application.LaboratoryWorks.Queries
{
    public class GetUpcomingLabworksQuery : IRequest<IEnumerable<LaboratoryWorkModel>>
    {
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
                //var upcomingLabs = _unitOfWork.LaboratoryWorks.Find(e => e.StartDate > currentDate);
                var upcomingLabs = _unitOfWork.LaboratoryWorks.All;

                var mappedEntites = _mapper.Map<IEnumerable<LaboratoryWork>, IEnumerable<LaboratoryWorkModel>>(upcomingLabs);

                return mappedEntites;
            }
        }
    }
}
