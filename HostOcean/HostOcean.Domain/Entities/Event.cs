using System;

namespace HostOcean.Domain.Entities
{
    public class LaboratoryWorkEvent : Entity
    {
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime RegistrationStartedAt { get; set; }

        public string LaboratoryWorkId { get; set; }
        public virtual LaboratoryWork LaboratoryWork { get; set; }

        public string QueueId { get; set; }
        public virtual Queue Queue { get; set; }
    }
}
