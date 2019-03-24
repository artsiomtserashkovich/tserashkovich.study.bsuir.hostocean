using System.Threading.Tasks;
using HostOcean.Domain.Entities;

namespace HostOcean.Application.Interfaces.Persistence
{
    public interface IQueueRepository: IRepository<Queue>
    {
        Task<Queue> GetQueueWithUserQueues(string id);
    }
}
