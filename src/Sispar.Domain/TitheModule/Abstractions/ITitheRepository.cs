using Sispar.Domain.BaseModule.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Domain.TitheModule.Abstractions
{
    public interface ITitheRepository : IRepository<Tithe>
    {
        Task<IEnumerable<Tithe>> GetByTitherIdAsync(Guid titherId);
    }
}
