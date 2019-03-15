using System;

namespace HostOcean.Application.Users.Models
{
    public class JwtToken
    {
        public string AccessToken { get; set; }

        public DateTime Expires { get; set; }

        public string Role { get; set; }
    }
}