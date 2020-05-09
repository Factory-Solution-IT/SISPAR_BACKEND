using AutoMapper;
using MediatR;
using Sispar.Api.Commands.Requests;
using Sispar.Api.Commands.Responses;
using Sispar.Core.Contracts.Services;
using Sispar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Api.Commands.Handlers
{
    public class CreateTitherHandler : IRequestHandler<CreateTitherRequest, CreateTitherResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitherService _titherService;

        public CreateTitherHandler(IMapper mapper, ITitherService titherService)
        {
            _mapper = mapper;
            _titherService = titherService;
        }

        public async Task<CreateTitherResponse> Handle(CreateTitherRequest request, CancellationToken cancellationToken)
        {
            var tither = _mapper.Map<Tither>(request);
            await _titherService.CreateAsync(tither);
            var result = _mapper.Map<CreateTitherResponse>(tither);

            return await Task.FromResult(result);
        }
    }
}
