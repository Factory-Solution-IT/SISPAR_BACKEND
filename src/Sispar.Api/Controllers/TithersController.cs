using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sispar.DataContract.TitherModule.Parameters;
using Sispar.Domain.TitherModule.Commands;
using Sispar.Domain.TitherModule.Queries;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sispar.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TithersController : Controller
    {
        private readonly IMediator _mediator;

        public TithersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //GET api/tithers
        [HttpGet]
        public async Task<IActionResult> GetAllTithers()
        {
            var result = await _mediator.Send(new ListTitherQuery());

            return (result == null || result.Count() == 0) ? NotFound() : (IActionResult)Ok(result);
        }

        //GET api/tithers/{id}
        [HttpGet("{id}", Name = "GetTitherById")]
        public async Task<IActionResult> GetTitherById(Guid id)
        {
            var result = await _mediator.Send(new GetTitherQuery(id));

            return (result == null) ? NotFound() : (IActionResult)Ok(result);
        }

        //POST api/tithers
        [HttpPost]
        public async Task<IActionResult> CreateTither(TitherParameters parameters)
        {
            var result = await _mediator.Send(new CreateTitherCommand(parameters));
            return (result != null)
                ? CreatedAtRoute(nameof(GetTitherById), new { result.Id }, result)
                : (IActionResult)BadRequest();
        }

        //PUT api/tithers
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTither(Guid id, TitherParameters parameters)
        {
            await _mediator.Send(new UpdateTitherCommand(id, parameters));
            return NoContent();
        }

        // DELETE api/tithers/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTither(Guid id)
        {
            await _mediator.Send(new DeleteTitherCommand(id));

            return NoContent();
        }
    }
}