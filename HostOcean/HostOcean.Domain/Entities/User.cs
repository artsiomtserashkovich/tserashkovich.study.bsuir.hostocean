using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace HostOcean.Domain.Entities
{
    public class User : IdentityUser
    {
        public string GroupId { get; set; }
        public Group Group { get; set; }
        public List<Place> Places { get; set; }
    }
}