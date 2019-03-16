using System;
using System.Collections.Generic;
using HostOcean.Application.LaboratoryWorks.Models;
using HostOcean.Application.UserQueues.Models;

namespace HostOcean.Application.Queues.Models
{
    public class QueueModel
    {
        public string Id { get; set; }
        public LaboratoryWorkModel LaboratoryWork { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime RegistrationStart { get; set; }
        public ICollection<UserQueueModel> UserQueues { get; private set; }
    }
}