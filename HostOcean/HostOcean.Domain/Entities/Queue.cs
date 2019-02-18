using System;
using System.Collections.Generic;

namespace HostOcean.Domain.Entities
{
    public class Queue : Entity
    {
        public Queue()
        {
            UserQueues = new HashSet<UserQueue>();
        }

        public LaboratoryWork LaboratoryWork { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime RegistrationStart { get; set; }

        public string LaboratoryWorkId { get; set; }
        
        public ICollection<UserQueue> UserQueues { get; private set; }
    }
}