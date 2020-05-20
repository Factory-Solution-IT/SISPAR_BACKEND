using AutoMapper;
using MediatR;
using Sispar.Api.Commands.Requests;
using Sispar.Api.Commands.Responses;
using Sispar.Core.Entities.Validators;
using Sispar.Core.Notification;
using Sispar.Domain.Contracts.Repositories;
using Sispar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Api.Commands.Handlers
{
    public class CreateTitheHandler : IRequestHandler<CreateTitheRequest, CreateTitheResponse>
    {
        private readonly IMapper _mapper;

        private readonly NotificationContext _notificationContext;
        private readonly ITitheRepository _titheRepository;

        public CreateTitheHandler(IMapper mapper, NotificationContext notificationContext, 
        ITitheRepository titheRepository)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            _titheRepository = titheRepository;
        }

        public async Task<CreateTitheResponse> Handle(CreateTitheRequest request, CancellationToken cancellationToken)
        {
            var tithe = _mapper.Map<Tithe>(request);
            if (!tithe.Validate(tithe, new TitheValidator()))
                _notificationContext.AddNotifications(tithe.ValidationResult);

            if (_notificationContext.HasNotifications)
                return await Task.FromResult(new CreateTitheResponse());

            await _titheRepository.AddAsync(tithe);

            var result = _mapper.Map<CreateTitheResponse>(tithe);

            return await Task.FromResult(result);
        }
    }
}
