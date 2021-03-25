using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_ZIwG.Infrastructure.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> GetAsync();

        Task<IEnumerable<T>> GetListAsync();

        Task CreateAsync(T entity);

        Task DeleteAsync(Guid entityId);

        Task UpdateAsync(T entity);
    }
}
