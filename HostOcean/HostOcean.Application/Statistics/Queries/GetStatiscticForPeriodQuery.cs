using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using HostOcean.Application.Exceptions;
using HostOcean.Application.Interfaces.Persistence;
using HostOcean.Application.Statistics.Models;
using HostOcean.Domain.Entities;
using MediatR;

namespace HostOcean.Application.Statistics.Queries
{
    public class GetStatiscticForPeriodQuery: IRequest<StatisticModel>
    {
        public string UserId { get; set; }
        public DateTime StartPeriod { get; set; }
        public DateTime EndPeriod { get; set; }

        public class GetStatiscticForPeriodQueryHandler: IRequestHandler<GetStatiscticForPeriodQuery, StatisticModel>
        {

            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetStatiscticForPeriodQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<StatisticModel> Handle(GetStatiscticForPeriodQuery request, CancellationToken cancellationToken)
            {
                if (await _unitOfWork.UserManager.FindByIdAsync(request.UserId) == null)
                    throw new NotFoundException(nameof(User),request.UserId);

                var count = await _unitOfWork.UserQueues.PredicateCountAsync(x => x.UserId == request.UserId);

                return new StatisticModel
                {
                    CountAssignedQueues = await _unitOfWork.UserQueues.PredicateCountAsync(x => x.UserId == request.UserId),
                    AveragePlace = 
                }
            }
        }
    }
}
