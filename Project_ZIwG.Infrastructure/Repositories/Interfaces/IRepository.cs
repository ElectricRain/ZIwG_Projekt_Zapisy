using System;
using System.Collections.Generic;

namespace Project_ZIwG.Infrastructure.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
         T Get(Guid entityId);

         IEnumerable<T> GetList();

         void Create(T entity);

         void Delete(Guid entityId);

         void Update(T entity);
    }
}
