using MediatR;
using Sispar.Api.Commands.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Api.Commands.Requests
{
    public class DeleteTitheRequest : IRequest<EmptyTitheResponse>
    {
        public Guid Id { get; set; }

        public DeleteTitheRequest(Guid id)
        {
            Id = id;
        }
    }
}
