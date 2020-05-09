using MediatR;
using Sispar.Api.Queries.Requests;
using Sispar.Api.Queries.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Api.Queries.Handlers
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, CustomerResponse>
    {
        public async Task<CustomerResponse> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var result = new CustomerResponse { Id = Guid.NewGuid(), Name = "Felipe", Email = "flpsno@hotmail.com", Date = DateTime.Now };

            return await Task.FromResult(result);
        }
    }
}