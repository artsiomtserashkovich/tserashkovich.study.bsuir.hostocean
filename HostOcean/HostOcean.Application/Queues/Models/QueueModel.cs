using HostOcean.Application.Events.Models;
using HostOcean.Application.UserQueues.Models;
using System;
using System.Collections.Generic;

namespace HostOcean.Application.Queues.Models
{
    public class QueueModel
    {
        public string Id { get; set; }
        public string EventId { get; set; }
        public LaboratoryWorkEventModel Event { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime RegistrationStart { get; set; }
        public ICollection<UserQueueModel> UserQueues { get; set; }
    }
}