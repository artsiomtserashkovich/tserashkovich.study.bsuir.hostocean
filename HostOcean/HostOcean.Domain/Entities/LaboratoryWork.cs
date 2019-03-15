using System;

namespace HostOcean.Domain.Entities
{
    public class LaboratoryWork : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public LaboratorySubGroup LaboratorySubGroup { get; set; }
        public virtual Group Group { get; set; }
        public virtual Queue Queue { get; set; }
    }
}