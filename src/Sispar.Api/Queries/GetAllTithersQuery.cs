using MediatR;
using Sispar.Api.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Api.Queries
{
    public class GetAllTithersQuery : IRequest<IEnumerable<TitherResponse>>
    {
        
    }
}
