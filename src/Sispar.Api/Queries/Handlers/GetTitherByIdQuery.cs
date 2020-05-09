using MediatR;
using Sispar.Api.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Api.Queries.Handlers
{
    public class GetTitherByIdQuery : IRequest<TitherResponse>
    {
        public Guid Id { get; set; }

        public GetTitherByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
