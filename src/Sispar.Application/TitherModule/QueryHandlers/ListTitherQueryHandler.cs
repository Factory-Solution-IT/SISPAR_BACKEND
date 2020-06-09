using AutoMapper;
using MediatR;
using Sispar.DataContract.TitherModule.Models;
using Sispar.Domain.TitherModule.Abstractions;
using Sispar.Domain.TitherModule.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Application.TitherModule.QueryHandlers
{
    public class ListTitherQueryHandler : IRequestHandler<ListTitherQuery, IEnumerable<TitherModel>>
    {
        private readonly IMapper _mapper;
        private readonly ITitherRepository _titherRepository;

        public ListTitherQueryHandler(IMapper mapper, ITitherRepository titherRepository)
        {
            _mapper = mapper;
            _titherRepository = titherRepository;
        }

        public async Task<IEnumerable<TitherModel>> Handle(ListTitherQuery request, CancellationToken cancellationToken)
        {
            var tithers = await _titherRepository.GetAllAsync();

            var result = _mapper.Map<IEnumerable<TitherModel>>(tithers.Where(_ => _.Deleted == false));

            return await Task.FromResult(result);
        }
    }
}