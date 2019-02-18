using System.Collections.Generic;

namespace HostOcean.Domain.Entities
{
    public class Group : Entity
    {
        public Group()
        {
            Users = new HashSet<User>();
            LaboratoryWorks = new HashSet<LaboratoryWork>();
        }

        public string Name { get; set; }

        public ICollection<User> Users { get; private set; }
        public ICollection<LaboratoryWork> LaboratoryWorks { get; private set; }
    }
}