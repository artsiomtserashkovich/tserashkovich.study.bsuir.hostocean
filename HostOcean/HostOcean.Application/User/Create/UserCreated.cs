using HostOcean.Application.Interfaces;
using HostOcean.Application.Notifications.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HostOcean.Application.User.Create
{
    public class UserCreated : INotification
    {
        public string UserId { get; set; }

        public class CustomerCreatedHandler : INotificationHandler<UserCreated>
        {
            private readonly INotificationService _notification;

            public CustomerCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(UserCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new Message());
            }
        }
    }
}