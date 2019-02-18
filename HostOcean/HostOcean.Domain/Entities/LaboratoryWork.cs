using System;

namespace HostOcean.Domain.Entities
{
    public class LaboratoryWork : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public SubGroup SubGroup { get; set; }
        public Group Group { get; set; }
        public Queue Queue { get; set; }

        public string GroupId { get; set; }
        public string QueueId { get; set; }
    }
}