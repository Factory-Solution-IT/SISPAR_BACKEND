using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sispar.Core.Entities;

namespace Sispar.Core.Contracts.Repositories
{
    public interface ITitheRepository : IRepository<Tithe>
    {
        Task<IEnumerable<Tithe>> GetByTitherIdAsync(Guid titherId);
    }
}