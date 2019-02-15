namespace HostOcean.Domain.Entities
{
    public class Labwork : Entity
    {
        public string Name { get; set; }
        public string GroupId { get; set; }
        public Group Group { get; set; }
    }
}
