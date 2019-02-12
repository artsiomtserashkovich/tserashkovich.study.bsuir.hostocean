using System.Collections.Generic;

namespace HostOcean.Domain.Entities
{
    public class University : Entity
    {
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public List<Faculty> Faculties { get; set; }
    }
}