using AutoMapper;
using MediatR;
using Sispar.DataContract.TitheModule.Models;
using Sispar.Domain.TitheModule.Abstractions;
using Sispar.Domain.TitheModule.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Application.TitheModule.QueryHandlers
{
    public class GetTitheByTitherIdQueryHandler : IRequestHandler<GetTitheByTitherIdQuery, IEnumerable<TitheModel>>
    {
        private readonly IMapper _mapper;
        private readonly ITitheRepository _titheRepository;

        public GetTitheByTitherIdQueryHandler(IMapper mapper, ITitheRepository titheRepository)
        {
            _mapper = mapper;
            _titheRepository = titheRepository;
        }

        public async Task<IEnumerable<TitheModel>> Handle(GetTitheByTitherIdQuery request, CancellationToken cancellationToken)
        {
            var tithes = await _titheRepository.GetByTitherIdAsync(request.TitherId);
            var result = _mapper.Map<IEnumerable<TitheModel>>(tithes.Where(_ => _.Deleted == false));

            return result;
        }
    }
}