using AutoMapper;
using MediatR;
using Sispar.Api.Commands;
using Sispar.Api.Commands.Responses;
using Sispar.Common.Helpers;
using Sispar.Core.Notification;
using Sispar.Domain.UserModule.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Api.CommandHandlers
{
    public class LoginHandler :
        IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;
        private readonly IUserRepository _userRepository;

        public LoginHandler(IMapper mapper, NotificationContext notificationContext,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            _userRepository = userRepository;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUserNameAsync(request.Username);
            if (user == null || user.Deleted == true)
            {
                _notificationContext.AddNotification("Not Found", "Usuário não encontrado");
                return await Task.FromResult(new LoginResponse());
            }

            if (user.Password != request.Password.Encrypt())
            {
                _notificationContext.AddNotification("Not Found", "Senha inválida");
                return await Task.FromResult(new LoginResponse());
            }

            var result = _mapper.Map<LoginResponse>(user);
            result.IsValid = true;
            return await Task.FromResult(result);
        }
    }
}