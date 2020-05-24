using MediatR;
using Sispar.Api.Commands.Responses;
using System;

namespace Sispar.Api.Commands
{
    public class DeleteTitherCommand : IRequest<NoContentResponse>
    {
        public Guid Id { get; set; }

        public DeleteTitherCommand(Guid id)
        {
            Id = id;
        }
    }
}