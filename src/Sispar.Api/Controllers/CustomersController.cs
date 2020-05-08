using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sispar.Api.Commands.Requests;
using Sispar.Api.Commands.Responses;

namespace Sispar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        [HttpPost]
        public async Task<CreateCustomerResponse> Create(
            [FromServices] IMediator mediator, 
            CreateCustomerRequest command
        )
        {
            return await mediator.Send(command);
        }
    }
}