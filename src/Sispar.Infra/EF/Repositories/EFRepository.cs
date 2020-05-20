using Microsoft.EntityFrameworkCore;
using Sispar.Domain.Contracts;
using Sispar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Infra.EF.Repositories
{
    public class EFRepository<T> : IRepository<T> where T: Entity
    {
        protected readonly SisparDataContext _context;

        public EFRepository(SisparDataContext context)
        {
            _context = context;
        }

        public void Add(T obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public async Task AddAsync(T obj)
        {
            await _context.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public void Delete(T obj)
        {
            _context.Remove(obj);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Edit(T obj)
        {
            _context.Update(obj);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
    }
}
