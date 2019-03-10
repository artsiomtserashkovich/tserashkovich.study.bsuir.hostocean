using System;

namespace HostOcean.Application.Exceptions
{
    public class AuthorizationException : Exception
    {
        public AuthorizationException(string username) 
            : base($"Error at authorization user \"{username}\".")
        {
        }
    }
}
