using AutoMapper;
using MediatR;
using Sispar.Api.Commands.Requests;
using Sispar.Api.Commands.Responses;
using Sispar.Core.Entities.Validators;
using Sispar.Core.Notification;
using Sispar.Domain.Contracts.Repositories;
using Sispar.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Api.Commands.Handlers
{
    public class CreateTitherHandler : IRequestHandler<CreateTitherRequest, CreateTitherResponse>
    {
        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;
        private readonly ITitherRepository _titherRepository;

        public CreateTitherHandler(IMapper mapper, NotificationContext notificationContext,
            ITitherRepository titherRepository)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            _titherRepository = titherRepository;
        }

        public async Task<CreateTitherResponse> Handle(CreateTitherRequest request, CancellationToken cancellationToken)
        {
            var tither = _mapper.Map<Tither>(request);
            if (!tither.Validate(tither, new TitherValidator()))
                _notificationContext.AddNotifications(tither.ValidationResult);

            if (_notificationContext.HasNotifications)
                return await Task.FromResult(new CreateTitherResponse());

            await _titherRepository.AddAsync(tither);
            var result = _mapper.Map<CreateTitherResponse>(tither);

            return await Task.FromResult(result);
        }
    }
}