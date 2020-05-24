using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sispar.Api.Commands;
using Sispar.Api.Commands.Responses;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config, IMediator mediator)
        {
            _mediator = mediator;
            _config = config;
        }

        [HttpPost]
        public async Task<IActionResult> RequestToken(LoginCommand loginCommand)
        {
            var loginResponse = await _mediator.Send(loginCommand);

            //return GenerateToken(user);
            return GenerateToken(loginResponse);
        }

        private OkObjectResult GenerateToken(LoginResponse loginResponse)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.NameId, loginResponse.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, loginResponse.Username)
                //new Claim(ClaimTypes.Role, "Admin"),
                //new Claim(ClaimTypes.Role, "TI"),
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
            //_userService.Dispose();
        }
    }
}