﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PocketBucket.Core.IRepositories;
using PocketBucket.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocketBucket.Core.Repositories
{
    public class GenericRepository<T>: IGenericRepository<T>where T : class
    {
        protected ApplicationDbContext context;
        protected DbSet<T> dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(
            ApplicationDbContext _context,
            ILogger logger
      )
        { 
            _context=context;
            _logger=logger;
            dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await dbSet.ToListAsync();
        }
        public virtual async Task<T> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }
        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
