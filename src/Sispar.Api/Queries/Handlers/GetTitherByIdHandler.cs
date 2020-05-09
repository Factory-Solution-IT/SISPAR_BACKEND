using AutoMapper;
using MediatR;
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
    public class GetTitherByIdHandler : IRequestHandler<GetTitherByIdQuery, TitherResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitherService _titherService;

        public GetTitherByIdHandler(IMapper mapper, ITitherService titherService)
        {
            _mapper = mapper;
            _titherService = titherService;
        }

        public async Task<TitherResponse> Handle(GetTitherByIdQuery request, CancellationToken cancellationToken)
        {
            var tither = await _titherService.GetByIdAsync(request.Id);
            var result = _mapper.Map<TitherResponse>(tither);
            return await Task.FromResult(result);
        }
    }
}
