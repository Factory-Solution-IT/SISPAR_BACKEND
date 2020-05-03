using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sispar.Core.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sispar.Api.Models.Tither;

namespace Sispar.Api.Controllers
{
    [Route("api/[controller]")]
    public class TithersController : Controller
    {
        private readonly ITitherService _titherService;

        public TithersController(ITitherService titherService)
        {
            _titherService = titherService;
        }

        //GET api/tithers
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tithers = await _titherService.GetAllAsync();

            if (tithers == null || tithers.Count() == 0)
                return NotFound();

            return Ok(tithers);
        }

        //GET api/tithers/{id}
        [HttpGet("{id}", Name = "GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var tither = await _titherService.GetByIdAsync(id);

            if (tither == null)
                return NotFound();

            return Ok(tither);
        }

        [HttpPost]
        public IActionResult Add([FromBody] AddVM model)
        {
            try
            {
                var newTither = _titherService.Register(model.Name, model.Address, model.Birthdate, model.Cpf, model.Telephone, model.Cellphone, model.Marriegedate, model.NameSpouse, model.DatebirthSpouse);
                return CreatedAtRoute("GetById", new { newTither.Id }, newTither);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        protected override void Dispose(bool disposing)
        {
            _titherService.Dispose();
        }
    }
}
