namespace HostOcean.Domain.Entities
{
    public class UserQueue : Entity
    {
        public short Order { get; set; }

        public User User { get; set; }
        public string UserId { get; set; }

        public Queue Queue { get; set; }
        public string QueueId { get; set; }
    }
}
