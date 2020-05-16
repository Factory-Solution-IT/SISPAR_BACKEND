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
    public class UpdateTitheHandler : IRequestHandler<UpdateTitheRequest, NoContentResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitheRepository _titheRepository;

        public UpdateTitheHandler(IMapper mapper, ITitheRepository titheRepository)
        {
            _mapper = mapper;
            _titheRepository = titheRepository;
        }

        public async Task<NoContentResponse> Handle(UpdateTitheRequest request, CancellationToken cancellationToken)
        {
            var titheFromRepo = await _titheRepository.GetByIdAsync(request.Id);

            _mapper.Map(request, titheFromRepo);

            _titheRepository.Edit(titheFromRepo);

            return await Task.FromResult(new NoContentResponse());
        }
    }
}
