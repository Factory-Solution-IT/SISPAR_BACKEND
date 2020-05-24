using MediatR;
using Sispar.Api.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Api.Queries
{
    public class GetTitheByIdQuery : IRequest<TitheResponse>
    {
        public Guid Id { get; set; }

        public GetTitheByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
