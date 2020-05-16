﻿using AutoMapper;
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
    public class UpdateTitherHandler : IRequestHandler<UpdateTitherRequest, NoContentResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitherService _titherService;

        public UpdateTitherHandler(IMapper mapper, ITitherService titherService)
        {
            _mapper = mapper;
            _titherService = titherService;
        }

        public async Task<NoContentResponse> Handle(UpdateTitherRequest request, CancellationToken cancellationToken)
        {
            var titherFromRepo = await _titherService.GetByIdAsync(request.Id);
            _mapper.Map(request, titherFromRepo);

            await _titherService.EditAsync(titherFromRepo);
            return await Task.FromResult(new NoContentResponse());
        }
    }
}