using AutoMapper;
using MediatR;
using Sispar.Api.Commands;
using Sispar.Api.Commands.Responses;
using Sispar.Core.Entities.Validators;
using Sispar.Core.Notification;
using Sispar.Domain.Contracts.Repositories;
using Sispar.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Api.Handlers
{
    public class TitheHandler :
        IRequestHandler<CreateTitheCommand, CreateTitheResponse>,
        IRequestHandler<UpdateTitheCommand, NoContentResponse>,
        IRequestHandler<DeleteTitheCommand, NoContentResponse>
    {
        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;
        private readonly ITitheRepository _titheRepository;

        public TitheHandler(IMapper mapper, NotificationContext notificationContext,
        ITitheRepository titheRepository)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            _titheRepository = titheRepository;
        }

        public async Task<CreateTitheResponse> Handle(CreateTitheCommand request, CancellationToken cancellationToken)
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

        public async Task<NoContentResponse> Handle(UpdateTitheCommand request, CancellationToken cancellationToken)
        {
            var titheFromRepo = await _titheRepository.GetByIdAsync(request.Id);

            _mapper.Map(request, titheFromRepo);

            _titheRepository.Edit(titheFromRepo);

            return await Task.FromResult(new NoContentResponse());
        }

        public async Task<NoContentResponse> Handle(DeleteTitheCommand request, CancellationToken cancellationToken)
        {
            var tithe = await _titheRepository.GetByIdAsync(request.Id);

            _titheRepository.Delete(tithe);

            return await Task.FromResult(new NoContentResponse());
        }
    }
}