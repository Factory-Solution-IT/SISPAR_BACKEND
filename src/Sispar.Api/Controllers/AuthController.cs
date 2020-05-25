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

            if (!loginResponse.IsValid)
                return BadRequest();

            return GenerateToken(loginResponse);
        }

        private OkObjectResult GenerateToken(LoginResponse loginResponse)
        {
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["SecurityKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("NameId", loginResponse.Id.ToString()),
                    new Claim("Username", loginResponse.Username),
                    new Claim("Name", loginResponse.FirstName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return Ok(new { token });
        }

        protected override void Dispose(bool disposing)
        {
            //_userService.Dispose();
        }
    }
}