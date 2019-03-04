using HostOcean.Application.Notifications.Models;
using System.Threading.Tasks;

namespace HostOcean.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(Message message);
    }
}