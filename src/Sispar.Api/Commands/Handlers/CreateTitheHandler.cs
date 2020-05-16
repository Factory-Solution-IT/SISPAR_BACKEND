using AutoMapper;
using MediatR;
using Sispar.Api.Commands.Requests;
using Sispar.Api.Commands.Responses;
using Sispar.Domain.Contracts.Repositories;
using Sispar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Api.Commands.Handlers
{
    public class CreateTitheHandler : IRequestHandler<CreateTitheRequest, CreateTitheResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitheRepository _titheRepository;

        public CreateTitheHandler(IMapper mapper, ITitheRepository titheRepository)
        {
            _mapper = mapper;
            _titheRepository = titheRepository;
        }

        public async Task<CreateTitheResponse> Handle(CreateTitheRequest request, CancellationToken cancellationToken)
        {
            var tithe = new Tithe()
            {
                ValueContribution = request.ValueContribution,
                DateContribution = request.DateContribution,
                TitherId = request.TitherId
            };

            await _titheRepository.AddAsync(tithe);

            var result = _mapper.Map<CreateTitheResponse>(tithe);

            return await Task.FromResult(result);
        }
    }
}
