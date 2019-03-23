using System;

namespace HostOcean.Application.Tokens.Models
{
    public class JwtToken
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public DateTime Expires { get; set; }

        public string Role { get; set; }
    }
}