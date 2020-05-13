using Sispar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sispar.Domain.Contracts.Services
{
    public interface ITitherService : IDisposable
    {
        Task<Tither> CreateAsync(Tither tither);
        Task EditAsync(Tither tither);

        Task<IEnumerable<Tither>> GetAllAsync();

        Task<Tither> GetByIdAsync(Guid id);

        Task RemoveAsync(Guid id);
    }
}