using System.Collections.Generic;

namespace HostOcean.Domain.Entities
{
    public class Speciality : Entity
    {
        public string Name { get; set; }
        public string FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        public List<Group> Groups { get; set; }
    }
}
