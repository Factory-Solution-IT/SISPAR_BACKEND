using MediatR;
using Sispar.Api.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Api.Queries.Requests
{
    public class GetUserByIdQuery : IRequest<UserResponse>
    {
        public Guid Id { get; set; }

        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
