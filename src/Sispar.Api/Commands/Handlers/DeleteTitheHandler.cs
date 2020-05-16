using AutoMapper;
using MediatR;
using Sispar.Api.Commands.Requests;
using Sispar.Api.Commands.Responses;
using Sispar.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Api.Commands.Handlers
{
    public class DeleteTitheHandler : IRequestHandler<DeleteTitheRequest, EmptyTitheResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitheRepository _titheRepository;

        public DeleteTitheHandler(IMapper mapper, ITitheRepository titheRepository)
        {
            _mapper = mapper;
            _titheRepository = titheRepository;
        }

        public async Task<EmptyTitheResponse> Handle(DeleteTitheRequest request, CancellationToken cancellationToken)
        {
            var tithe = await _titheRepository.GetByIdAsync(request.Id);

            _titheRepository.Delete(tithe);

            return await Task.FromResult(new EmptyTitheResponse());
        }
    }
}
