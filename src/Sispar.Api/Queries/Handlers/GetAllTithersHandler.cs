﻿using AutoMapper;
using MediatR;
using Sispar.Api.Queries.Requests;
using Sispar.Api.Queries.Responses;
using Sispar.Core.Notification;
using Sispar.Domain.Contracts.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Api.Queries.Handlers
{
    public class GetAllTithersHandler : IRequestHandler<GetAllTithersQuery, IEnumerable<TitherResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ITitherRepository _titherRepository;

        public GetAllTithersHandler(IMapper mapper, ITitherRepository titherRepository)
        {
            _mapper = mapper;
            _titherRepository = titherRepository;
        }

        public async Task<IEnumerable<TitherResponse>> Handle(GetAllTithersQuery request, CancellationToken cancellationToken)
        {
            var tithers = await _titherRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<TitherResponse>>(tithers);

            return await Task.FromResult(result);
        }
    }
}