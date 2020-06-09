using Sispar.DataContract.UserModule.Models;
using Sispar.DataContract.UserModule.Parameters;
using Sispar.Domain.BaseModule.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Domain.UserModule.Commands
{
    public class UpdateUserCommand : Command<UserParameters, bool>
    {
        public Guid Id { get; set; }

        public UpdateUserCommand(Guid id, UserParameters parameters)
            :base(parameters)
        {
            Id = id;
        }
    }
}
