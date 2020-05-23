using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Sispar.Api.Commands.Requests;
using Sispar.Api.Commands.Responses;
using Sispar.Core.Notification;
using Sispar.Domain.Contracts.Repositories;
using Sispar.Common.Helpers;

namespace Sispar.Api.Commands.Handlers
{
    public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
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

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            if (request.Password != request.ConfirmPassword)
            {
                _notificationContext.AddNotification("Not Found", "Senha e Confirma senha não conferem");
                return await Task.FromResult(new LoginResponse());
            }

            var user = await _userRepository.GetByUserNameAsync(request.Username);
            if (user == null)
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
            return await Task.FromResult(result);
        }
    }
}