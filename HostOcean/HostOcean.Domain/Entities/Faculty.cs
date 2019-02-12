using System.Collections.Generic;

namespace HostOcean.Domain.Entities
{
    public class Faculty : Entity
    {
        public string Name { get; set; }
        public List<Speciality> Specialities { get; set; }
        public string UniversityId { get; set; }
        public University University { get; set; }
    }
}
