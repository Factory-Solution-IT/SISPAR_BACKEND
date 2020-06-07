using MediatR;
using Sispar.Api.Commands.Responses;
using Sispar.DataContract.UserModule.Models;

namespace Sispar.Api.Commands
{
    public class LoginCommand : IRequest<LoginModel>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}