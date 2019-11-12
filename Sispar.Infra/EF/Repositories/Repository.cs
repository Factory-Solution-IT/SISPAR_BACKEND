using Microsoft.EntityFrameworkCore;
using Sispar.Core.Contracts;
using Sispar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Infra.EF.Repositories
{
    public class Repository<T> : IRepository<T> where T: Entity
    {
        protected readonly SisparDataContext _context;

        public Repository(SisparDataContext context)
        {
            _context = context;
        }

        public void Add(T obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
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
            return _context.Set<T>().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
    }
}
