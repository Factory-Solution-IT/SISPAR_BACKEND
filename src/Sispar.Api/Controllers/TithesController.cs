using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sispar.Api.Commands;
using Sispar.Api.Queries;
using Sispar.DataContract.TitheModule.Parameters;
using Sispar.Domain.TitheModule.Commands;
using Sispar.Domain.TitheModule.Queries;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sispar.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TithesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TithesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/tithes
        [HttpGet]
        public async Task<IActionResult> GetAllTithes()
        {
            var result = await _mediator.Send(new ListTitheQuery());
            return (result == null || result.Count() == 0) ? NotFound() : (IActionResult)Ok(result);
        }

        // GET: api/tithes/{id}
        [HttpGet("{id}", Name = "GetTitheById")]
        public async Task<IActionResult> GetTitheById(Guid id)
        {
            var result = await _mediator.Send(new GetTitheQuery(id));
            return (result == null) ? NotFound() : (IActionResult)Ok(result);
        }

        // GET: api/tithes/byTitherId/{id}
        [HttpGet("bytitherid/{titherId}")]
        public async Task<IActionResult> GetTithesByTitherId(Guid titherId)
        {
            var result = await _mediator.Send(new GetTithesByTitherIdQuery(titherId));
            return (result == null || result.Count() == 0) ? NotFound() : (IActionResult)Ok(result);
        }

        // POST: api/tithes
        [HttpPost]
        public async Task<IActionResult> CreateTithe(TitheParameters parameters)
        {
            var result = await _mediator.Send(new CreateTitheCommand(parameters));
            return CreatedAtRoute(nameof(GetTitheById), new { result.Id }, result);
        }

        // PUT: api/tithes
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTithe(Guid id, TitheParameters parameters)
        {
            await _mediator.Send(new UpdateTitheCommand(id, parameters));
            return NoContent();
        }

        // DELETE: api/tithes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTithe(Guid id)
        {
            var result = await _mediator.Send(new DeleteTitheCommand(id));
            return NoContent();
        }
    }
}