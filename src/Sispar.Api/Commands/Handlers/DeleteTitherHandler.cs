using AutoMapper;
using MediatR;
using Sispar.Api.Commands.Requests;
using Sispar.Api.Commands.Responses;
using Sispar.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Api.Commands.Handlers
{
    public class DeleteTitherHandler : IRequestHandler<DeleteTitherRequest, DeleteTitherResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitherService _titherService;

        public DeleteTitherHandler(IMapper mapper, ITitherService titherService)
        {
            _mapper = mapper;
            _titherService = titherService;
        }

        public async Task<DeleteTitherResponse> Handle(DeleteTitherRequest request, CancellationToken cancellationToken)
        {
            await _titherService.RemoveAsync(request.Id);
            var result = new DeleteTitherResponse();
            
            return await Task.FromResult(result);
        }
    }
}
