using AutoMapper;
using MediatR;
using Sispar.Api.Commands;
using Sispar.Api.Commands.Responses;
using Sispar.Core.Notification;
using Sispar.Domain.Contracts.Repositories;
using Sispar.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Api.Handlers
{
    public class UserHandler :
        IRequestHandler<CreateUserCommand, CreateUserResponse>,
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

            await _userRepository.AddAsync(user);

            var result = _mapper.Map<CreateUserResponse>(user);
            return await Task.FromResult(result);
        }

        public async Task<NoContentResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            _userRepository.Delete(user);

            return await Task.FromResult(new NoContentResponse());
        }
    }
}