using System.Threading.Tasks;

namespace HostOcean.Persistence.Interfaces
{
    public interface IHostOceanDataBaseContextInitializer
    {
        Task Initialize();
    }
}