using System;
using System.Collections.Generic;

namespace HostOcean.Domain.Entities
{
    public class Queue : Entity
    {
        public string LabworkId { get; set; }
        public Labwork Labwork { get; set; }
        public List<Place> Places { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? RegistradionStartedAt { get; set; }
    }
}