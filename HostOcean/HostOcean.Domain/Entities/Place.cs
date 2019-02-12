namespace HostOcean.Domain.Entities
{
    public class Place : Entity
    {
        public short Order { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string QueueId { get; set; }
        public Queue Queue { get; set; }
    }
}
