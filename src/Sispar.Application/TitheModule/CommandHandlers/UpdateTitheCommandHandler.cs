using AutoMapper;
using MediatR;
using Sispar.Core.Notification;
using Sispar.Domain.TitheModule.Abstractions;
using Sispar.Domain.TitheModule.Commands;
using Sispar.Domain.TitheModule.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Application.TitheModule.CommandHandlers
{
    public class UpdateTitheCommandHandler : IRequestHandler<UpdateTitheCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;
        private readonly ITitheRepository _titheRepository;

        public UpdateTitheCommandHandler(IMapper mapper, NotificationContext notificationContext,
        ITitheRepository titheRepository)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            _titheRepository = titheRepository;
        }

        public async Task<bool> Handle(UpdateTitheCommand request, CancellationToken cancellationToken)
        {
            var titheFromRepo = await _titheRepository.GetByIdAsync(request.Id);

            _mapper.Map(request.parameters, titheFromRepo);

            if (!titheFromRepo.Validate(titheFromRepo, new TitheValidator()))
            {
                _notificationContext.AddNotifications(titheFromRepo.ValidationResult);
                return await Task.FromResult(false);
            }

            _titheRepository.Edit(titheFromRepo);

            return await Task.FromResult(true);
        }
    }
}
