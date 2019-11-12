using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sispar.Core.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class TitherController : Controller
    {
        private readonly ITitherService _titherService;

        public TitherController(ITitherService titherService)
        {
            _titherService = titherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tithers = await _titherService.GetAllAsync();
            return Ok(tithers);
        }

        [HttpGet("{id}", Name = "GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var tither = await _titherService.GetByIdAsync(id);

            if (tither == null)
                return BadRequest("Dizimista não encontrado");

            return Ok(tither);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Models.Tither.AddVM model)
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
