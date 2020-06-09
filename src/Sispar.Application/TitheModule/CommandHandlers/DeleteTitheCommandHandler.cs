using AutoMapper;
using MediatR;
using Sispar.Core.Notification;
using Sispar.Domain.TitheModule.Abstractions;
using Sispar.Domain.TitheModule.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Application.TitheModule.CommandHandlers
{
    public class DeleteTitheCommandHandler : IRequestHandler<DeleteTitheCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;
        private readonly ITitheRepository _titheRepository;

        public DeleteTitheCommandHandler(IMapper mapper, NotificationContext notificationContext,
        ITitheRepository titheRepository)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            _titheRepository = titheRepository;
        }

        public async Task<bool> Handle(DeleteTitheCommand request, CancellationToken cancellationToken)
        {
            var tithe = await _titheRepository.GetByIdAsync(request.Id);

            if (tithe == null)
            {
                _notificationContext.AddNotification("NotFound", "Contribuição não encontrada");
                return false;
            }

            tithe.Delete();
            _titheRepository.Edit(tithe);

            return true;
        }
    }
}