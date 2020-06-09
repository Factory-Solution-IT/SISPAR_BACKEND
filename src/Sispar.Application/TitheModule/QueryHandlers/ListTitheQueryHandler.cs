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
    public class ListTitheQueryHandler : IRequestHandler<ListTitheQuery, IEnumerable<TitheModel>>
    {
        private readonly IMapper _mapper;
        private readonly ITitheRepository _titheRepository;

        public ListTitheQueryHandler(IMapper mapper, ITitheRepository titheRepository)
        {
            _mapper = mapper;
            _titheRepository = titheRepository;
        }

        public async Task<IEnumerable<TitheModel>> Handle(ListTitheQuery request, CancellationToken cancellationToken)
        {
            var tithes = await _titheRepository.GetAllAsync();

            var result = _mapper.Map<IEnumerable<TitheModel>>(tithes.Where(_ => _.Deleted == false));

            return await Task.FromResult(result);
        }
    }
}