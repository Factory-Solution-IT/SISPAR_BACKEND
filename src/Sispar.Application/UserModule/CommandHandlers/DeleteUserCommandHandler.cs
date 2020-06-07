using AutoMapper;
using MediatR;
using Sispar.Core.Notification;
using Sispar.Domain.UserModule.Abstractions;
using Sispar.Domain.UserModule.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Application.UserModule.CommandHandlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IMapper mapper,
            NotificationContext notificationContext,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
            {
                _notificationContext.AddNotification("NotFound", "Usuário não encontrado");
                return false;
            }

            user.Delete();

            _userRepository.Edit(user);

            return true;
        }
    }
}