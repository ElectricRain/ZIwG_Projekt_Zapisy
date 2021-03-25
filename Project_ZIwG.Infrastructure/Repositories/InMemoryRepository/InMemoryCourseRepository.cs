using Project_ZIwG.Infrastructure.Entities;
using Project_ZIwG.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_ZIwG.Infrastructure.Repositories.InMemoryRepository
{
    class InMemoryCourseRepository : ICourseRepository
    {
        public Task CreateAsync(CourseEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<CourseEntity> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseEntity>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CourseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
