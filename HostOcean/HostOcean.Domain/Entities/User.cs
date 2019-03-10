using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace HostOcean.Domain.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            UserQueues = new HashSet<UserQueue>();
        }

        public User(string userName) : base(userName)
        {
            UserQueues = new HashSet<UserQueue>();
        }

        public UserSubGroup UserSubGroup { get; set; }
        public string GroupId { get; set; }
        public virtual Group Group { get; set; }
        
        public virtual ICollection<UserQueue> UserQueues { get; private set; }
    }
}