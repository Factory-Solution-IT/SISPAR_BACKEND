using MediatR;
using Sispar.Api.Commands.Responses;

namespace Sispar.Api.Commands.Requests
{
    public class LoginRequest : IRequest<LoginResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}