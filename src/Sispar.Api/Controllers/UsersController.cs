using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sispar.Api.Commands;
using Sispar.Api.Queries;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sispar.Api.Controllers
{
    //[Authorize]
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
            var result = await _mediator.Send(new GetAllUsersQuery());
            return (result == null || result.Count() == 0) ? NotFound() : (IActionResult)Ok(result);
        }

        // GET api/users/{id}
        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));
            return (result == null) ? NotFound() : (IActionResult)Ok(result);
        }

        // POST api/users
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand createUserCommand)
        {
            var result = await _mediator.Send(createUserCommand);
            return CreatedAtRoute(nameof(GetUserById), new { result.Id }, result);
        }

        // PUT api/users
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand updateUserCommand)
        {
            await _mediator.Send(updateUserCommand);
            return NoContent();
        }

        //[HttpPost]
        //[Route("ChangePassword")]
        //public IActionResult ChangePassword([FromBody] Models.Tither.ChangePasswordVM model)
        //{
        //    try
        //    {
        //        _userService.ChangePassword(model.Username, model.Password, model.NewPassword, model.ConfirmNewPassword);
        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        // DELETE api/users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _mediator.Send(new DeleteUserCommand(id));
            return NoContent();
        }
    }
}