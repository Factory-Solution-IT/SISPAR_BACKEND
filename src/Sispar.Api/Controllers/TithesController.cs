using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Sispar.Api.Commands.Requests;
using Sispar.Api.Queries.Requests;

namespace Sispar.Api.Controllers
{
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
            var result = await _mediator.Send(new GetAllTithesQuery());
            return (result == null || result.Count() == 0) ? NotFound() : (IActionResult)Ok(result);
        }

        // GET: api/tithes/{id}
        [HttpGet("{id}", Name = "GetTitheById")]
        public async Task<IActionResult> GetTitheById(Guid id)
        {
            var result = await _mediator.Send(new GetTitheByIdQuery(id));
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
        public async Task<IActionResult> CreateTithe(CreateTitheRequest createTitheRequest)
        {
            var result = await _mediator.Send(createTitheRequest);
            return CreatedAtRoute(nameof(GetTitheById), new { result.Id }, result);
        }

        // PUT: api/tithes/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTithe(Guid id, UpdateTitheRequest updateTitheRequest)
        {
            updateTitheRequest.Id = id;
            await _mediator.Send(updateTitheRequest);
            return NoContent();
        }

        // DELETE: api/tithes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTithe(Guid id)
        {
            var result = await _mediator.Send(new DeleteTitheRequest(id));
            return NoContent();
        }
    }
}
