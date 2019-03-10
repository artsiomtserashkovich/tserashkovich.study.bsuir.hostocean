using HostOcean.Application.Tokens.Models;
using MediatR;

namespace HostOcean.Application.Tokens.Queries
{
    public class GenerateJwtTokenQuery : IRequest<Token>
    {
        public string Username { get; set; }
    }
}