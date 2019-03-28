using System.Collections.Generic;

namespace HostOcean.Domain.Entities
{
    public class LaboratoryWork : Entity
    {
        public LaboratoryWork()
        {
            LaboratoryWorkEvents = new HashSet<LaboratoryWorkEvent>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Lecturer { get; set; }
        public LaboratorySubGroup LaboratorySubGroup { get; set; }
        
        public string GroupId { get; set; }
        public virtual Group Group { get; set; }

        public virtual ICollection<LaboratoryWorkEvent> LaboratoryWorkEvents { get; set; }
    }
}