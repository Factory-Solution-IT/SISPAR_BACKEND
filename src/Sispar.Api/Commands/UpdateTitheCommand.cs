using MediatR;
using Sispar.Api.Commands.Responses;
using System;

namespace Sispar.Api.Commands
{
    public class UpdateTitheCommand : IRequest<NoContentResponse>
    {
        public Guid Id { get; set; }
        public decimal ValueContribution { get; set; }
        public DateTime DateContribution { get; set; }
    }
}