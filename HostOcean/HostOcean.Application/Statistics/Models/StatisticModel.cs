using System;
using System.Collections.Generic;
using System.Text;

namespace HostOcean.Application.Statistics.Models
{
    public class StatisticModel
    {
        public int CountQueues { get; set; }
        public TimeSpan AverageTakeQueueTime { get; set; }
        public double AveragePlace { get; set; }
        public IEnumerable<QueueStatisticModel> QueueStatistics { get; set; }
    }

    public class QueueStatisticModel
    {
        public string QueueId { get; set; }
        public string QueueTitle { get; set; }
        public DateTime QueueStartTime { get; set; }
        public TimeSpan TakeQueueTime { get; set; }
        public int Place { get; set; }
        public int ParticipantsCount { get; set; }
    }
}
