using System;

namespace HostOcean.Domain.Entities
{
    public sealed class LaboratoryWorkEvent : Entity
    {
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime RegistrationStartedAt { get; set; }

        public string LaboratoryWorkId { get; set; }
        public LaboratoryWork LaboratoryWork { get; set; }

        public string QueueId { get; set; }
        public Queue Queue { get; set; }
    }
}
