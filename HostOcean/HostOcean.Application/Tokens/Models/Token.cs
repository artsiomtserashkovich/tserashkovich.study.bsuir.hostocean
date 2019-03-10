using System;

namespace HostOcean.Application.Tokens.Models
{
    public class Token
    {
        public string AccessToken { get; set; }

        public DateTime Expires { get; set; }

        public string Role { get; set; }
    }
}