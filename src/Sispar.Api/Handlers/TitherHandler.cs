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
    public class TitherHandler :
        IRequestHandler<CreateTitherCommand, CreateTitherResponse>,
        IRequestHandler<UpdateTitherCommand, NoContentResponse>,
        IRequestHandler<DeleteTitherCommand, NoContentResponse>
    {
        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;
        private readonly ITitherRepository _titherRepository;

        public TitherHandler(IMapper mapper, NotificationContext notificationContext,
            ITitherRepository titherRepository)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            _titherRepository = titherRepository;
        }

        public async Task<CreateTitherResponse> Handle(CreateTitherCommand request, CancellationToken cancellationToken)
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

        public async Task<NoContentResponse> Handle(UpdateTitherCommand request, CancellationToken cancellationToken)
        {
            var titherFromRepo = await _titherRepository.GetByIdAsync(request.Id);
            _mapper.Map(request, titherFromRepo);
            _titherRepository.Edit(titherFromRepo);

            return await Task.FromResult(new NoContentResponse());
        }
        public async Task<NoContentResponse> Handle(DeleteTitherCommand request, CancellationToken cancellationToken)
        {
            var tither = await _titherRepository.GetByIdAsync(request.Id);
            _titherRepository.Delete(tither);

            return await Task.FromResult(new NoContentResponse());
        }
    }
}