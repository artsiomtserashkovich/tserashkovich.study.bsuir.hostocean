using System;

namespace HostOcean.Domain.Entities
{
    public class LaboratoryWork : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public LaboratorySubGroup LaboratorySubGroup { get; set; }
        public Group Group { get; set; }
        public Queue Queue { get; set; }
    }
}