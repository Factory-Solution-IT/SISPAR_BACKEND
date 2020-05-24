using MediatR;
using Sispar.Api.Commands.Responses;
using System;

namespace Sispar.Api.Commands
{
    public class DeleteUserCommand : IRequest<NoContentResponse>
    {
        public Guid Id { get; set; }

        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }
    }
}