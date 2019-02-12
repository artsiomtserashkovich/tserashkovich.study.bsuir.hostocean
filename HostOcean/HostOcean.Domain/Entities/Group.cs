using System.Collections.Generic;

namespace HostOcean.Domain.Entities
{
    public class Group : Entity
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public string SpecialityId { get; set; }
        public Speciality Speciality { get; set; }
        public List<Labwork> Labworks { get; set; }
    }
}
