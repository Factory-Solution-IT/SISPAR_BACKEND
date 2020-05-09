using AutoMapper;
using Sispar.Core.Contracts;
using Sispar.Core.Contracts.Services;
using Sispar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sispar.Business.Services
{
    public class TitherService : ITitherService
    {
        private readonly IMapper _mapper;
        private readonly ITitherRepository _ctx;

        public TitherService(IMapper mapper, ITitherRepository titherRepository)
        {
            _mapper = mapper;
            _ctx = titherRepository;
        }

        public async Task<IEnumerable<Tither>> GetAllAsync()
        {
            return await _ctx.GetAllAsync();
        }

        public async Task<Tither> GetByIdAsync(Guid id)
        {
            return await _ctx.GetByIdAsync(id);
        }

        public async Task<Tither> CreateAsync(Tither tither)
        {
            await _ctx.AddAsync(tither);
            return tither;
        }

        public async Task RemoveAsync(Guid id)
        {
            var tither = await _ctx.GetByIdAsync(id);

            _ctx.Delete(tither);
        }

        public void Dispose() => _ctx.Dispose();
    }
}