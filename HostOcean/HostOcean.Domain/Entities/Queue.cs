using System;
using System.Collections.Generic;

namespace HostOcean.Domain.Entities
{
    public class Queue : Entity
    {
        public string EventId { get; set; }
        public virtual LaboratoryWorkEvent LaboratoryWorkEvent { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime RegistrationStart { get; set; }
        
        public virtual ICollection<UserQueue> UserQueues { get; set; }
    }
}