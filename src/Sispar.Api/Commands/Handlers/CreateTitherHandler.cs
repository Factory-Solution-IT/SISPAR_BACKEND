using AutoMapper;
using MediatR;
using Sispar.Api.Commands.Requests;
using Sispar.Api.Commands.Responses;
using Sispar.Domain.Contracts.Repositories;
using Sispar.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Api.Commands.Handlers
{
    public class CreateTitherHandler : IRequestHandler<CreateTitherRequest, CreateTitherResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitherRepository _titherRepository;

        public CreateTitherHandler(IMapper mapper, ITitherRepository titherRepository)
        {
            _mapper = mapper;
            _titherRepository = titherRepository;
        }

        public async Task<CreateTitherResponse> Handle(CreateTitherRequest request, CancellationToken cancellationToken)
        {
            var tither = _mapper.Map<Tither>(request);
            await _titherRepository.AddAsync(tither);
            var result = _mapper.Map<CreateTitherResponse>(tither);

            return await Task.FromResult(result);
        }
    }
}