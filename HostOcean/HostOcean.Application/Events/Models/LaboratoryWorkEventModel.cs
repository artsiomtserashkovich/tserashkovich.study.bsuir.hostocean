using HostOcean.Application.LaboratoryWorks.Models;
using HostOcean.Application.Queues.Models;
using System;

namespace HostOcean.Application.Events.Models
{
    public class LaboratoryWorkEventModel
    {
        public string Id { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }

        public string LaboratoryWorkId { get; set; }
        public LaboratoryWorkModel LaboratoryWork { get; set; }

        public string QueueId { get; set; }
        public QueueModel Queue { get; set; }
    }
}
