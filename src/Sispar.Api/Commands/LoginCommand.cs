using MediatR;
using Sispar.Api.Commands.Responses;

namespace Sispar.Api.Commands
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}