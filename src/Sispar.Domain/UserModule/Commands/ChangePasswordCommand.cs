using MediatR;
using Sispar.DataContract.UserModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Domain.UserModule.Commands
{
    public class ChangePasswordCommand : IRequest<UserModel>
    {
        public Guid UserId { get; set; }
        public string ActualPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
