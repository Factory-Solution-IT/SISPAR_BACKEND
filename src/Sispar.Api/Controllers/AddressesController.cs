using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sispar.Infra.ExternalServices;

namespace Sispar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {

        [HttpGet("{zipCode}")]
        public async Task<IActionResult> GetByZipCoode(string zipCode)
        {
            var addressService = new AddressService();

            var result = await addressService.DoSearh(zipCode);
            return result != null ? Ok(result) : (IActionResult) NotFound();
        }
    }
}