using MediatR;
using Sispar.Api.Queries.Requests;
using Sispar.Api.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Api.Queries.Handlers
{
    public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, List<CustomerResponse>>
    {
        public async Task<List<CustomerResponse>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var result = new List<CustomerResponse> {
                new CustomerResponse { Id = Guid.NewGuid(), Name = "Felipe", Email = "flpsno@hotmail.com", Date = DateTime.Now}
            };

            return await Task.FromResult(result);
        }
    }
}