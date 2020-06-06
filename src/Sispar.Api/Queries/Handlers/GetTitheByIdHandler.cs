using AutoMapper;
using MediatR;
using Sispar.Api.Queries.Responses;
using Sispar.Domain.TitheModule.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Api.Queries.Handlers
{
    public class GetTitheByIdHandler : IRequestHandler<GetTitheByIdQuery, TitheResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitheRepository _titheRepository;

        public GetTitheByIdHandler(IMapper mapper, ITitheRepository titheRepository)
        {
            _mapper = mapper;
            _titheRepository = titheRepository;
        }

        public async Task<TitheResponse> Handle(GetTitheByIdQuery request, CancellationToken cancellationToken)
        {
            var tithe = await _titheRepository.GetByIdAsync(request.Id);

            var result = (tithe != null && tithe.Deleted == false) ? _mapper.Map<TitheResponse>(tithe) : null;

            return await Task.FromResult(result);
        }
    }
}