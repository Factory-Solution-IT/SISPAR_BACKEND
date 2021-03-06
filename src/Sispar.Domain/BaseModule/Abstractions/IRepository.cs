﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sispar.Domain.BaseModule.Abstractions
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        void Add(T obj);

        Task AddAsync(T obj);

        void Edit(T obj);

        // void Delete(T obj);

        IEnumerable<T> GetAll();

        T GetById(Guid id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid id);
    }
}