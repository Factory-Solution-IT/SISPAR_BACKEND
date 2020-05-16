using MediatR;
using Sispar.Api.Commands.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Api.Commands.Requests
{
    public class UpdateTitheRequest : IRequest<NoContentResponse>
    {
        public Guid Id { get; set; }
        public decimal ValueContribution { get; set; }
        public DateTime DateContribution { get; set; }
        public Guid TitherId { get; set; }
    }
}
