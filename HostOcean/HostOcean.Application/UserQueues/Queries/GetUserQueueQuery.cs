using AutoMapper;
using HostOcean.Application.Interfaces.Persistence;
using HostOcean.Application.UserQueues.Models;
using HostOcean.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HostOcean.Application.UserQueues.Queries
{
    public class GetUserQueueQuery : IRequest<UserQueueModel>
    {
        public string UserId { get; set; }
        public string QueueId { get; set; }

        public class GetUserQueueQueryHandler : IRequestHandler<GetUserQueueQuery, UserQueueModel>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;

            public GetUserQueueQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
            }

            public async Task<UserQueueModel> Handle(GetUserQueueQuery request, CancellationToken cancellationToken)
            {
                var entity = _unitOfWork.UserQueues.Find(e => e.UserId == request.UserId && e.QueueId == request.QueueId).FirstOrDefault();

                var model = _mapper.Map<UserQueue, UserQueueModel>(_unitOfWork.UserQueues.Get(entity.Id));

                return model;
            }
        }
    }
}