using Microsoft.EntityFrameworkCore;
using Sispar.Domain.TitheModule;
using Sispar.Domain.TitheModule.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sispar.Infra.EF.Repositories
{
    public class EFTitheRepository : EFRepository<Tithe>, ITitheRepository
    {
        public EFTitheRepository(SisparDataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Tithe>> GetByTitherIdAsync(Guid thitherId)
        {
            return await _context.Tithes.Where(x => x.TitherId == thitherId).ToListAsync();
        }
    }
}