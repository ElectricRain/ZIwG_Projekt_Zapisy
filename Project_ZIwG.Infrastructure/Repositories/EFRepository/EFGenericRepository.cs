using Microsoft.EntityFrameworkCore;
using Project_ZIwG.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_ZIwG.Infrastructure.Repositories.EFRepository
{
    public abstract class EFGenericRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public EFGenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Create(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Guid entityId)
        {
            _dbSet.Remove(Get(entityId));
            _context.SaveChanges();
        }

        public T Get(Guid entityId)
        {
            return _dbSet.Find(entityId);
        }

        public IEnumerable<T> GetList()
        {
            return _dbSet.ToList();
        }

        public void Update(T entity)
        {
            var IdProperty = entity.GetType().GetProperty("Id").GetValue(entity, null);
            var entityToChange = Get((Guid)IdProperty);
            _context.Entry(entityToChange).CurrentValues.SetValues(entity);
        }
    }
}
