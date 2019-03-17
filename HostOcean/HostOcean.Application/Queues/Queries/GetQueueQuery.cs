using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HostOcean.Application.Exceptions;
using HostOcean.Application.Interfaces.Persistence;
using HostOcean.Application.Queues.Models;
using MediatR;

namespace HostOcean.Application.Queues.Queries
{
    public class GetQueueQuery : IRequest<QueueModel>
    {
        public string Id { get; set; }

        public class GetQueueQueryHandler : IRequestHandler<GetQueueQuery, QueueModel>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;

            public GetQueueQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
            }

            public async Task<QueueModel> Handle(GetQueueQuery request, CancellationToken cancellationToken)
            {
                var result = _unitOfWork.Queues.SingleOrDefault(q => q.Id == request.Id);

                if (result == null) throw new NotFoundException("Queue", request.Id);

                var model = _mapper.Map<Domain.Entities.Queue, QueueModel>(result);
                model.UserQueues = model.UserQueues.OrderBy(c => c.CreatedOn).ToList();

                return model;
            }
        }
    }
}