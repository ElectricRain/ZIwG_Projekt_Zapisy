using Project_ZIwG.Infrastructure.Entities;
using Project_ZIwG.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_ZIwG.Infrastructure.Repositories.InMemoryRepository
{
    public class InMemoryUserRepository : IUserRepository
    {
        public Task CreateAsync(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserEntity>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
