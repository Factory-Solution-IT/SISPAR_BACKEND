using AutoMapper;
using MediatR;
using Sispar.Core.Notification;
using Sispar.DataContract.TitheModule.Models;
using Sispar.Domain.TitheModule;
using Sispar.Domain.TitheModule.Abstractions;
using Sispar.Domain.TitheModule.Commands;
using Sispar.Domain.TitheModule.Validators;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Application.TitheModule.CommandHandlers
{
    public class CreateTitheCommandHandler : IRequestHandler<CreateTitheCommand, TitheModel>
    {
        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;
        private readonly ITitheRepository _titheRepository;

        public CreateTitheCommandHandler(IMapper mapper, NotificationContext notificationContext,
        ITitheRepository titheRepository)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            _titheRepository = titheRepository;
        }

        public async Task<TitheModel> Handle(CreateTitheCommand request, CancellationToken cancellationToken)
        {
            var tithe = _mapper.Map<Tithe>(request.parameters);

            if (!tithe.Validate(tithe, new TitheValidator()))
            {
                _notificationContext.AddNotifications(tithe.ValidationResult);
                return await Task.FromResult<TitheModel>(null);
            }

            await _titheRepository.AddAsync(tithe);

            var result = _mapper.Map<TitheModel>(tithe);

            return await Task.FromResult(result);
        }
    }
}