using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace HostOcean.Domain.Entities
{
    public class User : IdentityUser
    {
        public User() : base()
        {
            UserQueues = new HashSet<UserQueue>();
        }

        public User(string userName) : base(userName)
        {
            UserQueues = new HashSet<UserQueue>();
        }

        public UserSubGroup UserSubGroup { get; set; }
        public Group Group { get; set; }
        
        public ICollection<UserQueue> UserQueues { get; private set; }
    }
}