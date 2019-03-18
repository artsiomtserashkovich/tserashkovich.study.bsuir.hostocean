using HostOcean.Application.Queues.Models;
using HostOcean.Application.Users.Models;

namespace HostOcean.Application.UserQueues.Models
{
    public class UserQueueModel
    {
        public string CreatedOn { get; set; }

        public UserModel User { get; set; }

        public QueueModel Queue { get; set; }
    }
}