using MediatR;
using Sispar.Api.Commands.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Api.Commands
{
    public class DeleteTitheCommand : IRequest<NoContentResponse>
    {
        public Guid Id { get; set; }

        public DeleteTitheCommand(Guid id)
        {
            Id = id;
        }
    }
}
