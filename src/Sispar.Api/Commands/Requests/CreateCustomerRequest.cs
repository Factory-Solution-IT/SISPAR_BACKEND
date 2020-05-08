using MediatR;
using Sispar.Api.Commands.Responses;

namespace Sispar.Api.Commands.Requests
{
    public class CreateCustomerRequest : IRequest<CreateCustomerResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }

    }
}