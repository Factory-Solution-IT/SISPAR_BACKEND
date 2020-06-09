using AutoMapper;
using MediatR;
using Sispar.Core.Notification;
using Sispar.DataContract.UserModule.Models;
using Sispar.Domain.UserModule;
using Sispar.Domain.UserModule.Abstractions;
using Sispar.Domain.UserModule.Commands;
using Sispar.Domain.UserModule.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Application.UserModule.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserModel>
    {
        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IMapper mapper,
            NotificationContext notificationContext,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            _userRepository = userRepository;
        }

        public async Task<UserModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
                if (!request.parameters.Password.Equals(request.parameters.ConfirmPassword))
                {
                    _notificationContext.AddNotification("Password", "Senha e Confirma Senha não conferem");
                    return await Task.FromResult<UserModel>(null);
                }

                var user = _mapper.Map<User>(request.parameters);
                user.EncriptPassword();

                if (!user.Validate(user, new UserValidator()))
                {
                    _notificationContext.AddNotifications(user.ValidationResult);
                    return await Task.FromResult<UserModel>(null);
                }

                await _userRepository.AddAsync(user);

                var result = _mapper.Map<UserModel>(user);
                return await Task.FromResult(result);
        }
    }
}
