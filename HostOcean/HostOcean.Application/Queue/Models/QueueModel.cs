using HostOcean.Application.LaboratoryWorks.Models;
using HostOcean.Application.UserQueue.Models;
using System;
using System.Collections.Generic;

namespace HostOcean.Application.Queue.Models
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