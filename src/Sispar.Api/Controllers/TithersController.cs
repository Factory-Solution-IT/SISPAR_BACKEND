﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sispar.Core.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sispar.Api.Models.Tither;
using AutoMapper;
using Sispar.Api.Dtos;

namespace Sispar.Api.Controllers
{
    [Route("api/[controller]")]
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
        [HttpGet("{id}", Name = "GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var tither = await _titherService.GetByIdAsync(id);

            if (tither == null)
                return NotFound();

            return Ok(_mapper.Map<TitherReadDto>(tither));
        }
        
        protected override void Dispose(bool disposing)
        {
            _titherService.Dispose();
        }
    }
}
