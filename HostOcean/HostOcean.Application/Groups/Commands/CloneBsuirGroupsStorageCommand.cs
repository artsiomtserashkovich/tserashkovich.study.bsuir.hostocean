using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HostOcean.Application.Extension;
using HostOcean.Application.Interfaces.Infrastructure;
using HostOcean.Application.Interfaces.Persistance;
using HostOcean.Domain.Entities;
using MediatR;

namespace HostOcean.Application.Groups.Commands
{
    public class CloneBsuirGroupsStorageCommand : IRequest
    {
        public class CloneBsuirGroupsStorageCommandHandler : IRequestHandler<CloneBsuirGroupsStorageCommand>
        {
            private readonly IBsuirGroupService _bsuirGroupService;
            private readonly IUnitOfWork _unitOfWork;

            public CloneBsuirGroupsStorageCommandHandler(IBsuirGroupService bsuirGroupService,IUnitOfWork unitOfWork)
            {
                _bsuirGroupService = bsuirGroupService;
                _unitOfWork = unitOfWork;
            }

            public async Task<Unit> Handle(CloneBsuirGroupsStorageCommand request, CancellationToken cancellationToken)
            {
                var groups = await _bsuirGroupService.GetGroupsFromBsuirIIS();

                var splitedGroups = await groups.SplitByPredicateAsync(NewGroupPredicate);

                _unitOfWork.Groups.AddRange(splitedGroups.NoMatch);
                _unitOfWork.Groups.UpdateRange(splitedGroups.Match);

                return Unit.Value;
            }

            private async Task<bool> NewGroupPredicate(Group group) =>
                 await _unitOfWork.Groups.IsExistByIdAsync(group.Id);
            
        }
    }
}