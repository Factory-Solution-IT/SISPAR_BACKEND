using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sispar.Api.Commands.Requests;
using Sispar.Api.Commands.Responses;

namespace Sispar.Api.Commands.Handlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
    {
        public Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            // verifica se o cliente ja esta cadastrado

            // valida os dados

            // insere o client

            // envia o email de boas vindas

            var result = new CreateCustomerResponse
            {
                Id = Guid.NewGuid(),
                Name = "Felipe",
                Email = "flspno@hotmail.com",
                Date = DateTime.UtcNow
            };

            return Task.FromResult(result);
        }
    }
}