using AutoMapper;
using MediatR;
using Sispar.Api.Commands;
using Sispar.Api.Commands.Responses;
using Sispar.Core.Entities.Validators;
using Sispar.Core.Notification;
using Sispar.Core.Contracts.Repositories;
using Sispar.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Api.CommandHandlers
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
            { 
                _notificationContext.AddNotifications(tithe.ValidationResult);
                return await Task.FromResult(new CreateTitheResponse());
            }

            await _titheRepository.AddAsync(tithe);

            var result = _mapper.Map<CreateTitheResponse>(tithe);

            return await Task.FromResult(result);
        }

        public async Task<NoContentResponse> Handle(UpdateTitheCommand request, CancellationToken cancellationToken)
        {
            var titheFromRepo = await _titheRepository.GetByIdAsync(request.Id);

            _mapper.Map(request, titheFromRepo);

            if (!titheFromRepo.Validate(titheFromRepo, new TitheValidator()))
            { 
                _notificationContext.AddNotifications(titheFromRepo.ValidationResult);
                return await Task.FromResult(new NoContentResponse());
            }

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