using MediatR;
using Sispar.Api.Queries.Responses;
using System;

namespace Sispar.Api.Queries.Requests
{
    public class GetCustomerByIdQuery : IRequest<CustomerResponse>
    {
        public Guid Id { get; set; }

        public GetCustomerByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}