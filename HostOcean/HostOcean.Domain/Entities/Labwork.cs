namespace HostOcean.Domain.Entities
{
    public class Labwork : Entity
    {
        public string Name { get; set; }
        public Group Group { get; set; }
    }
}
