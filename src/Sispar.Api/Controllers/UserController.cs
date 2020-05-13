using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sispar.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
                return BadRequest("Usuário não encontrado");

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Register([FromBody] Models.Tither.RegisterVM model)
        {
            try
            {
                var newUser = _userService.Register(model.Username, model.Password, model.ConfirmPassword);
                return CreatedAtRoute("GetUserById", new { newUser.Id }, newUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("ChangePassword")]
        public IActionResult ChangePassword([FromBody] Models.Tither.ChangePasswordVM model)
        {
            try
            {
                _userService.ChangePassword(model.Username, model.Password, model.NewPassword, model.ConfirmNewPassword);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        protected override void Dispose(bool disposing)
        {
            _userService.Dispose();
        }
    }
}
