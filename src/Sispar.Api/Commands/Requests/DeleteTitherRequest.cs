using MediatR;
using Sispar.Api.Commands.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Api.Commands.Requests
{
    public class DeleteTitherRequest : IRequest<NoContentResponse>
    {
        public Guid Id { get; set; }

        public DeleteTitherRequest(Guid id)
        {
            Id = id;
        }
    }
}
