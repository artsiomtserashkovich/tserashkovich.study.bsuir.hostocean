using HostOcean.Application.Queue.Models;
using HostOcean.Application.User.Models;

namespace HostOcean.Application.UserQueue.Models
{
    public class UserQueueModel
    {
        public short Order { get; set; }

        public UserModel User { get; set; }

        public QueueModel Queue { get; set; }
    }
}