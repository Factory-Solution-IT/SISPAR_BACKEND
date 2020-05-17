﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Sispar.Api.Commands.Requests;
using Sispar.Api.Queries.Requests;
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
        public async Task<IActionResult> CreateUser(CreateUserRequest createUserRequest)
        {
            var result = await _mediator.Send(createUserRequest);
            return CreatedAtRoute(nameof(GetUserById), new { result.Id }, result);
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
            await _mediator.Send(new DeleteUserRequest(id));
            return NoContent();
        }
    }
}