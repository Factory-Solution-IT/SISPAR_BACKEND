using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
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

        // GET: api/Tithes
        [HttpGet]
        public async Task<IActionResult> GetAllTithes()
        {
            var result = await _mediator.Send(new GetAllTithesQuery());
            return Ok(result);
        }

        // GET: api/Tithes/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Tithes
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Tithes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
