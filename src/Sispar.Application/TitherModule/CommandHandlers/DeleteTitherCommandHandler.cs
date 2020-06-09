using AutoMapper;
using MediatR;
using Sispar.Core.Notification;
using Sispar.Domain.TitherModule.Abstractions;
using Sispar.Domain.TitherModule.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Application.TitherModule.CommandHandlers
{
    public class DeleteTitherCommandHandler : IRequestHandler<DeleteTitherCommand, bool>
    {
        private readonly NotificationContext _notificationContext;
        private readonly ITitherRepository _titherRepository;

        public DeleteTitherCommandHandler(NotificationContext notificationContext,
           ITitherRepository titherRepository)
        {
            _notificationContext = notificationContext;
            _titherRepository = titherRepository;
        }

        public async Task<bool> Handle(DeleteTitherCommand request, CancellationToken cancellationToken)
        {
            var tither = await _titherRepository.GetByIdAsync(request.Id);

            if (tither == null)
            {
                _notificationContext.AddNotification("NotFound", "Dizimista não encontrado");
                return false;
            }

            tither.Delete();

            _titherRepository.Edit(tither);

            return true;
        }
    }
}