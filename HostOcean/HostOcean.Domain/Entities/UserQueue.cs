using System;

namespace HostOcean.Domain.Entities
{
    public class UserQueue : Entity
    {
        public DateTime CreatedOn { get; set; }

        public virtual User User { get; set; }
        public string UserId { get; set; }

        public virtual Queue Queue { get; set; }
        public string QueueId { get; set; }
    }
}
