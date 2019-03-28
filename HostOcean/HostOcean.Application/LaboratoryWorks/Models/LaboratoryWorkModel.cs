using HostOcean.Application.Groups.Models;
using HostOcean.Domain.Entities;

namespace HostOcean.Application.LaboratoryWorks.Models
{
    public class LaboratoryWorkModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Lecturer { get; set; }
        public LaboratorySubGroup LaboratorySubGroup { get; set; }

        public string GroupId { get; set; }
        public virtual GroupModel Group { get; set; }
    }
}