using AutoMapper;
using MediatR;
using Sispar.Core.Notification;
using Sispar.Domain.UserModule.Abstractions;
using Sispar.Domain.UserModule.Commands;
using Sispar.Domain.UserModule.Validators;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Application.UserModule.CommandHandlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IMapper mapper,
            NotificationContext notificationContext,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userFromRepo = await _userRepository.GetByIdAsync(request.Id);

            _mapper.Map(request, userFromRepo);

            if (!userFromRepo.Validate(userFromRepo, new UserValidator()))
            {
                _notificationContext.AddNotifications(userFromRepo.ValidationResult);
                return false;
            }

            _userRepository.Edit(userFromRepo);

            return true;
        }
    }
}