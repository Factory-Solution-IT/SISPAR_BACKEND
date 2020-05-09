using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sispar.Api.Commands.Requests;
using Sispar.Api.Queries.Handlers;
using Sispar.Api.Queries.Requests;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sispar.Api.Controllers
{
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
            var query = new GetAllTithersQuery();
            var result = await _mediator.Send(query);

            return (result == null || result.Count() == 0) ? NotFound() : (IActionResult)Ok(result);
        }

        //GET api/tithers/{id}
        [HttpGet("{id}", Name = "GetTitherById")]
        public async Task<IActionResult> GetTitherById(Guid id)
        {
            var query = new GetTitherByIdQuery(id);
            var result = await _mediator.Send(query);

            return (result == null) ? NotFound() : (IActionResult)Ok(result);
        }

        //POST api/tithers
        [HttpPost]
        public async Task<IActionResult> CreateTither(CreateTitherRequest createTitherRequest)
        {
            var result = await _mediator.Send(createTitherRequest);
            return CreatedAtRoute(nameof(GetTitherById), new { result.Id }, result);
        }

        // DELETE api/tithers/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTither(Guid id)
        {
            var request = new DeleteTitherRequest(id);
            await _mediator.Send(request);

            return NoContent();
        }

        protected override void Dispose(bool disposing)
        {
            //_titherService.Dispose();
        }
    }
}