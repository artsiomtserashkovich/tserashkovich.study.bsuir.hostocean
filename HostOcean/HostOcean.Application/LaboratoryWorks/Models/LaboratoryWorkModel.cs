using System;

namespace HostOcean.Application.LaboratoryWorks.Models
{
    public class LaboratoryWorkModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Lecturer { get; set; }
        public DateTime StartDate { get; set; }
        public string QueueId { get; set; }
    }
}