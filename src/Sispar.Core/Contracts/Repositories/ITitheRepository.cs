using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sispar.Domain.Entities;

namespace Sispar.Domain.Contracts.Repositories
{
    public interface ITitheRepository : IRepository<Tithe>
    {
        Task<IEnumerable<Tithe>> GetByTitherIdAsync(Guid titherId);
    }
}