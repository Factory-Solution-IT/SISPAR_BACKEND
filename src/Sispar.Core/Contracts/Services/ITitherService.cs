using Sispar.Core.Dtos;
using Sispar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Core.Contracts.Services
{
    public interface ITitherService : IDisposable
    {
        Task<Tither> RegisterAsync(TitherCreateDto titherCreateDto);
        Task<IEnumerable<Tither>> GetAllAsync();
        Task<Tither> GetByIdAsync(Guid id);
    }
}
