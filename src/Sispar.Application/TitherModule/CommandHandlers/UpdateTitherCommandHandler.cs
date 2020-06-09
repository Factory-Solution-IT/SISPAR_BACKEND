using AutoMapper;
using MediatR;
using Sispar.Core.Notification;
using Sispar.Domain.TitherModule.Abstractions;
using Sispar.Domain.TitherModule.Commands;
using Sispar.Domain.TitherModule.Validators;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Application.TitherModule.CommandHandlers
{
    public class UpdateTitherCommandHandler : IRequestHandler<UpdateTitherCommand, bool>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IMapper _mapper;
        private readonly ITitherRepository _titherRepository;

        public UpdateTitherCommandHandler(NotificationContext notificationContext,
            IMapper mapper,
            ITitherRepository titherRepository)
        {
            _notificationContext = notificationContext;
            _mapper = mapper;
            _titherRepository = titherRepository;
        }

        public async Task<bool> Handle(UpdateTitherCommand request, CancellationToken cancellationToken)
        {
            var titherFromRepo = await _titherRepository.GetByIdAsync(request.Id);

            _mapper.Map(request.parameters, titherFromRepo);

            if (!titherFromRepo.Validate(titherFromRepo, new TitherValidator()))
            {
                _notificationContext.AddNotifications(titherFromRepo.ValidationResult);
                return false;
            }

            _titherRepository.Edit(titherFromRepo);

            return true;
        }
    }
}