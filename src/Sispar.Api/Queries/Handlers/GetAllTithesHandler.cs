using AutoMapper;
using MediatR;
using Sispar.Api.Queries.Responses;
using Sispar.Core.Contracts.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Api.Queries.Handlers
{
    public class GetAllTithesHandler : IRequestHandler<GetAllTithesQuery, IEnumerable<TitheResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ITitheRepository _titheRepository;

        public GetAllTithesHandler(IMapper mapper, ITitheRepository titheRepository)
        {
            _mapper = mapper;
            _titheRepository = titheRepository;
        }

        public async Task<IEnumerable<TitheResponse>> Handle(GetAllTithesQuery request, CancellationToken cancellationToken)
        {
            var tithes = await _titheRepository.GetAllAsync();

            var result = _mapper.Map<IEnumerable<TitheResponse>>(tithes);

            return await Task.FromResult(result);
        }
    }
}