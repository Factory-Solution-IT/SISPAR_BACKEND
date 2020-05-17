using MediatR;
using Sispar.Api.Queries.Responses;
using System.Collections;
using System.Collections.Generic;

namespace Sispar.Api.Queries.Requests
{
    public class GetAllTithesQuery : IRequest<IEnumerable<TitheResponse>>
    {
    }
}