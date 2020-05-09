using Sispar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sispar.Core.Contracts.Services
{
    public interface ITitherService : IDisposable
    {
        Task<Tither> CreateAsync(Tither tither);

        Task<IEnumerable<Tither>> GetAllAsync();

        Task<Tither> GetByIdAsync(Guid id);

        Task RemoveAsync(Guid id);
    }
}