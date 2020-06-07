using AutoMapper;
using MediatR;
using Sispar.Core.Notification;
using Sispar.DataContract.TitherModule.Models;
using Sispar.Domain.TitherModule;
using Sispar.Domain.TitherModule.Abstractions;
using Sispar.Domain.TitherModule.Commands;
using Sispar.Domain.TitherModule.Enums;
using Sispar.Domain.TitherModule.Validators;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Application.TitherModule.CommandHandlers
{
    public class CreateTitherCommandHandler : IRequestHandler<CreateTitherCommand, TitherModel>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IMapper _mapper;
        private readonly ITitherRepository _titherRepository;

        public CreateTitherCommandHandler(NotificationContext notificationContext, 
            IMapper mapper,
            ITitherRepository titherRepository)
        {
            _notificationContext = notificationContext;
            _mapper = mapper;
            _titherRepository = titherRepository;
        }

        public async Task<TitherModel> Handle(CreateTitherCommand request, CancellationToken cancellationToken)
        {
            var tither = _mapper.Map<Tither>(request.parameters);

            if (!tither.Validate(tither, new TitherValidator()))
            {
                _notificationContext.AddNotifications(tither.ValidationResult);
                return await Task.FromResult<TitherModel>(null);
            }

            await _titherRepository.AddAsync(tither);
            var result = _mapper.Map<TitherModel>(tither);

            return await Task.FromResult(result);
        }
    }
}