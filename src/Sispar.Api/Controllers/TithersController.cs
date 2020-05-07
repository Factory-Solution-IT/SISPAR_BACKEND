using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sispar.Core.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Sispar.Core.Dtos;

namespace Sispar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TithersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITitherService _titherService;

        public TithersController(IMapper mapper, ITitherService titherService)
        {
            _mapper = mapper;
            _titherService = titherService;
        }

        //GET api/tithers
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tithers = await _titherService.GetAllAsync();

            if (tithers == null || tithers.Count() == 0)
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<TitherReadDto>>(tithers));
        }

        //GET api/tithers/{id}
        [HttpGet("{id}", Name = "GetTitherById")]
        public async Task<IActionResult> GetTitherById(Guid id)
        {
            var tither = await _titherService.GetByIdAsync(id);

            if (tither == null)
                return NotFound();

            return Ok(_mapper.Map<TitherReadDto>(tither));
        }

        //POST api/tithers
        [HttpPost]
        public async Task<IActionResult> CreateTither(TitherCreateDto titherCreateDto)
        {
            var tither = await _titherService.RegisterAsync(titherCreateDto);

            var titherReadDto = _mapper.Map<TitherReadDto>(tither);

            return CreatedAtRoute(nameof(GetTitherById), new { titherReadDto.Id }, titherReadDto);
        }

        protected override void Dispose(bool disposing)
        {
            _titherService.Dispose();
        }
    }
}
