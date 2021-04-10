using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_ZIwG.Infrastructure.Interfaces
{
    public interface IRepository<T>
    {
         T Get(Guid entityId);

         IEnumerable<T> GetList();

         void Create(T entity);

         void Delete(Guid entityId);

         void Update(T entity);
    }
}
