using AutoMapper;
using MediatR;
using Sispar.DataContract.TitheModule.Models;
using Sispar.Domain.TitheModule.Abstractions;
using Sispar.Domain.TitheModule.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Application.TitheModule.QueryHandlers
{
    public class GetTitheQueryHandler : IRequestHandler<GetTitheQuery, TitheModel>
    {
        private readonly IMapper _mapper;
        private readonly ITitheRepository _titheRepository;

        public GetTitheQueryHandler(IMapper mapper, ITitheRepository titheRepository)
        {
            _mapper = mapper;
            _titheRepository = titheRepository;
        }

        public async Task<TitheModel> Handle(GetTitheQuery request, CancellationToken cancellationToken)
        {
            var tithe = await _titheRepository.GetByIdAsync(request.Id);

            var result = (tithe != null && tithe.Deleted == false) ? _mapper.Map<TitheModel>(tithe) : null;

            return await Task.FromResult(result);
        }
    }
}