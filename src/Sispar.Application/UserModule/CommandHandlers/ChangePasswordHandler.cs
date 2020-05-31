using MediatR;
using Sispar.Common.Helpers;
using Sispar.Core.Notification;
using Sispar.DataContract.UserModule.Models;
using Sispar.Domain.UserModule.Abstractions;
using Sispar.Domain.UserModule.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Application.UserModule.CommandHandlers
{
    public class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand, UserModel>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IUserRepository _userRepo;

        public ChangePasswordHandler(NotificationContext notificationContext, IUserRepository userRepository)
        {
            _notificationContext = notificationContext;
            _userRepo = userRepository;
        }

        public async Task<UserModel> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            if (!request.NewPassword.Equals(request.ConfirmNewPassword))
                _notificationContext.AddNotification("NotFound", "Senha e Confirma Senha são diferentes");

            var userFromRepo = await _userRepo.GetByIdAsync(request.UserId);

            if (userFromRepo == null)
                _notificationContext.AddNotification("NotFound", "Usuário não encontrado");
            else
            { 
                if (!userFromRepo.Password.Equals(request.ActualPassword.Encrypt()))
                    _notificationContext.AddNotification("NotFound", "Senha atual inválida");
            }

            if (_notificationContext.HasNotifications)
                return await Task.FromResult<UserModel>(null);

            userFromRepo.SetPassword(request.NewPassword, request.ConfirmNewPassword);
            _userRepo.Edit(userFromRepo);

            return await Task.FromResult(new UserModel());
        }
    }
}