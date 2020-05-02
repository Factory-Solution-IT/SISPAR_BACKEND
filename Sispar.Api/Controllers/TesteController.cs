using Microsoft.AspNetCore.Mvc;

namespace Sispar.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TesteController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new { tudoCerto = "uhuu"});
        }
    }
}