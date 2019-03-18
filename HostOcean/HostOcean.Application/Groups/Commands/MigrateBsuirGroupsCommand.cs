using System.Threading;
using System.Threading.Tasks;
using HostOcean.Application.Extension;
using HostOcean.Application.Interfaces.Infrastructure;
using HostOcean.Application.Interfaces.Persistence;
using MediatR;

namespace HostOcean.Application.Groups.Commands
{
    public class MigrateBsuirGroupsCommand : IRequest
    {
        public class MigrateBsuirGroupsCommandHandler : IRequestHandler<MigrateBsuirGroupsCommand>
        {
            private readonly IBsuirGroupService _bsuirGroupService;
            private readonly IUnitOfWork _unitOfWork;

            public MigrateBsuirGroupsCommandHandler(IBsuirGroupService bsuirGroupService,IUnitOfWork unitOfWork)
            {
                _bsuirGroupService = bsuirGroupService;
                _unitOfWork = unitOfWork;
            }

            public async Task<Unit> Handle(MigrateBsuirGroupsCommand request, CancellationToken cancellationToken)
            {
                var groups = await _bsuirGroupService.GetGroupsFromBsuirIIS();

                var splitedGroups = await groups.SplitByPredicateAsync(NewGroupPredicate);

                _unitOfWork.Groups.AddRange(splitedGroups.Match);
                _unitOfWork.Groups.UpdateRange(splitedGroups.NoMatch);

                await _unitOfWork.SaveAsync();

                return await Unit.Task;
            }

            private async Task<bool> NewGroupPredicate(Domain.Entities.Group group) =>
                 !(await _unitOfWork.Groups.IsExistByIdAsync(group.Id));
            
        }
    }
}