using System.Collections.Generic;
using System.Threading.Tasks;
using HostOcean.Domain.Entities;

namespace HostOcean.Infrastructure.BsuirGroupService
{
    public interface IBsuirGroupService
    {
        Task<IEnumerable<Group>> GetGroupsFromBsuirIIS();
    }
}
