using AutoMapper;
using MediatR;
using Sispar.Api.Queries.Responses;
using Sispar.Domain.TitheModule.Abstractions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Api.Queries.Handlers
{
    public class GetTithesByTitherIdHandler : IRequestHandler<GetTithesByTitherIdQuery, IEnumerable<TitheResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ITitheRepository _titheRepository;

        public GetTithesByTitherIdHandler(IMapper mapper, ITitheRepository titheRepository)
        {
            _mapper = mapper;
            _titheRepository = titheRepository;
        }

        public async Task<IEnumerable<TitheResponse>> Handle(GetTithesByTitherIdQuery request, CancellationToken cancellationToken)
        {
            var tithes = await _titheRepository.GetByTitherIdAsync(request.TitherId);
            var result = _mapper.Map<IEnumerable<TitheResponse>>(tithes);

            return await Task.FromResult(result);
        }
    }
}