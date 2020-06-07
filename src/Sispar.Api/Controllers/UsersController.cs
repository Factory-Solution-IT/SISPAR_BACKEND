using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sispar.DataContract.UserModule.Parameters;
using Sispar.Domain.UserModule.Commands;
using Sispar.Domain.UserModule.Queries;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sispar.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/users
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _mediator.Send(new ListUserQuery());
            return (result == null || result.Count() == 0) ? NotFound() : (IActionResult)Ok(result);
        }

        // GET api/users/{id}
        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var result = await _mediator.Send(new GetUserQuery(id));
            return (result == null) ? NotFound() : (IActionResult)Ok(result);
        }

        // POST api/users
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserParameters parameters)
        {
            var result = await _mediator.Send(new CreateUserCommand(parameters));
            return CreatedAtRoute(nameof(GetUserById), new { result.Id }, result);
        }

        // PUT api/users
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, UserParameters parameters)
        {
            await _mediator.Send(new UpdateUserCommand(id, parameters));
            return NoContent();
        }

        // POST api/users
        [HttpPost("changePassword")]
        public async Task<IActionResult> ChangePasswork(ChangePasswordCommand changePasswordCommand)
        {
            await _mediator.Send(changePasswordCommand);
            return NoContent();
        }

        // DELETE api/users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _mediator.Send(new DeleteUserCommand(id));
            return NoContent();
        }
    }
}