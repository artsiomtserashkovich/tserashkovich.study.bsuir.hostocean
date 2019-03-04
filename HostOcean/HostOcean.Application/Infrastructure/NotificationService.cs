using HostOcean.Application.Interfaces;
using HostOcean.Application.Notifications.Models;
using System.Threading.Tasks;

namespace HostOcean.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(Message message)
        {
            return Task.CompletedTask;
        }
    }
}