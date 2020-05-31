using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Sispar.Api.Commands;
using Sispar.Api.Commands.Responses;
using Sispar.Core.Notification;
using Sispar.Domain.UserModule;
using Sispar.Domain.UserModule.Abstractions;
using Sispar.Domain.UserModule.Validators;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Api.CommandHandlers
{
    public class UserHandler :
        IRequestHandler<CreateUserCommand, CreateUserResponse>,
        IRequestHandler<UpdateUserCommand, NoContentResponse>,
        IRequestHandler<DeleteUserCommand, NoContentResponse>
    {
        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;
        private readonly IUserRepository _userRepository;

        public UserHandler(IMapper mapper,
            NotificationContext notificationContext,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.Password.Equals(request.ConfirmPassword))
            {
                _notificationContext.AddNotification("Password", "Senha e Confirma Senha não conferem");
                return await Task.FromResult(new CreateUserResponse());
            }

            var user = _mapper.Map<User>(request);
            user.EncriptPassword();

            if (!user.Validate(user, new UserValidator()))
            {
                _notificationContext.AddNotifications(user.ValidationResult);
                return await Task.FromResult(new CreateUserResponse());
            }

            await _userRepository.AddAsync(user);

            var result = _mapper.Map<CreateUserResponse>(user);
            return await Task.FromResult(result);
        }

        public async Task<NoContentResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userFromRepo = await _userRepository.GetByIdAsync(request.Id);

            _mapper.Map(request, userFromRepo);

            if (!userFromRepo.Validate(userFromRepo, new UserValidator()))
            {
                _notificationContext.AddNotifications(userFromRepo.ValidationResult);
                return await Task.FromResult(new NoContentResponse());
            }

            _userRepository.Edit(userFromRepo);

            return await Task.FromResult(new NoContentResponse());
        }

        public async Task<NoContentResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            _userRepository.Delete(user);

            return await Task.FromResult(new NoContentResponse());
        }
    }
}