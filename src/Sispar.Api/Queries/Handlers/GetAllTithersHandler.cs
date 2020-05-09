using AutoMapper;
using MediatR;
using Sispar.Api.Queries.Requests;
using Sispar.Api.Queries.Responses;
using Sispar.Core.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Api.Queries.Handlers
{
    public class GetAllTithersHandler : IRequestHandler<GetAllTithersQuery, IEnumerable<TitherResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ITitherService _titherService;

        public GetAllTithersHandler(IMapper mapper, ITitherService titherService)
        {
            _mapper = mapper;
            _titherService = titherService;
        }
        public async Task<IEnumerable<TitherResponse>> Handle(GetAllTithersQuery request, CancellationToken cancellationToken)
        {
            var tithers = await _titherService.GetAllAsync();
            var result = _mapper.Map<IEnumerable<TitherResponse>>(tithers);
            return await Task.FromResult(result);
        }
    }
}
