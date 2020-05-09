using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sispar.Api.Commands.Requests;
using Sispar.Api.Commands.Responses;
using Sispar.Api.Queries.Requests;
using System;
using System.Threading.Tasks;

namespace Sispar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var query = new GetAllCustomersQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {
            var query = new GetCustomerByIdQuery(id);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

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