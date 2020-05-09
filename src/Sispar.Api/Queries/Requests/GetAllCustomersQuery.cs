using MediatR;
using Sispar.Api.Queries.Responses;
using System.Collections.Generic;

namespace Sispar.Api.Queries.Requests
{
    public class GetAllCustomersQuery : IRequest<List<CustomerResponse>>
    {
    }
}