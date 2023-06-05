﻿using Server.DataAccess;
using Microsoft.EntityFrameworkCore;

using static Server.Interfaces.IGenericRepository;

namespace Server.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public ShopContext dbContext;
        public DbSet<T> DbSet { get; set; }

        public GenericRepository(ShopContext _context)
        {
            this.dbContext = _context;
            this.DbSet = this.dbContext.Set<T>();
            
        }

        public virtual Task<List<T>> GetAllAsync()
        {
            return this.DbSet.ToListAsync();
        }

        public virtual Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T obj)
        {
            throw new NotImplementedException();
        }

        public void Update(T obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(T obj)
        {
            throw new NotImplementedException();
        }

       
    }
}