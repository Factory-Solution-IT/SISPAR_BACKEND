using Sispar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Core.Contracts
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        void Add(T obj);
        void Edit(T obj);
        void Delete(T obj);

        IEnumerable<T> GetAll();
        T GetById(int id);

        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
