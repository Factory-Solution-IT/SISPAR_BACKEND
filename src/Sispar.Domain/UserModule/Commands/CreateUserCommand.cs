using Sispar.DataContract.UserModule.Models;
using Sispar.DataContract.UserModule.Parameters;
using Sispar.Domain.BaseModule.Command;

namespace Sispar.Domain.UserModule.Commands
{
    public class CreateUserCommand : Command<UserParameters, UserModel>
    {
        public CreateUserCommand(UserParameters parameters) : base(parameters)
        {
        }
    }
}