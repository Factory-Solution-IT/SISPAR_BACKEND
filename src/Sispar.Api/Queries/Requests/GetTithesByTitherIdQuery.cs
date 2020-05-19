using System;
using System.Collections.Generic;
using MediatR;
using Sispar.Api.Queries.Responses;

namespace Sispar.Api.Queries.Requests
{
    public class GetTithesByTitherIdQuery : IRequest<IEnumerable<TitheResponse>>
    {
        public Guid TitherId { get; set; }

        public GetTithesByTitherIdQuery(Guid titherId)
        {
            TitherId = titherId;
        }
    }
}