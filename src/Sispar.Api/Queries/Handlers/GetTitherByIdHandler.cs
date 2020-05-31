using AutoMapper;
using MediatR;
using Sispar.Api.Queries.Responses;
using Sispar.Core.Contracts.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Api.Queries.Handlers
{
    public class GetTitherByIdHandler : IRequestHandler<GetTitherByIdQuery, TitherResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitherRepository _titherRepository;

        public GetTitherByIdHandler(IMapper mapper, ITitherRepository titherRepository)
        {
            _mapper = mapper;
            _titherRepository = titherRepository;
        }

        public async Task<TitherResponse> Handle(GetTitherByIdQuery request, CancellationToken cancellationToken)
        {
            var tither = await _titherRepository.GetByIdAsync(request.Id);
            var result = _mapper.Map<TitherResponse>(tither);

            return await Task.FromResult(result);
        }
    }
}