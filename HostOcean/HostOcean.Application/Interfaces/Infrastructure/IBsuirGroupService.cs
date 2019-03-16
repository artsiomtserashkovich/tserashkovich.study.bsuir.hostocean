using System.Collections.Generic;
using System.Threading.Tasks;
using HostOcean.Domain.Entities;

namespace HostOcean.Application.Interfaces.Infrastructure
{
    public interface IBsuirGroupService
    {
        Task<IEnumerable<Group>> GetGroupsFromBsuirIIS();
    }
}
