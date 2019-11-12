using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sispar.Core.Contracts.Services;
using Sispar.Core.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;

        public AuthController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpPost]
        public async Task<IActionResult> RequestToken([FromBody] Models.Auth.LoginVM model)
        {
            try
            {
                var user = await _userService.LoginAsync(model.Username, model.Password);

                return GenerateToken(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private OkObjectResult GenerateToken(User user)
        {
            var claims = new[] {

                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, user.Username),
//                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "TI"),
                //new Claim("permissions","addUser")
            };

            var key =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecurityKey"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "sispar",
                audience: "sispar/client",
                claims: claims,
                expires: DateTime.UtcNow.AddMonths(1),
                notBefore: DateTime.UtcNow,
                signingCredentials: credentials
            );

            return Ok(
                new { token = new JwtSecurityTokenHandler().WriteToken(token) }
               );
        }


        protected override void Dispose(bool disposing)
        {
            _userService.Dispose();
        }

    }
}
