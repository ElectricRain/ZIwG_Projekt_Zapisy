using Project_ZIwG.Infrastructure.Entities;
using Project_ZIwG.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_ZIwG.Infrastructure.Repositories.InMemoryRepository
{
    class InMemorySubjectRepository : ISubjectRepository
    {
        public Task CreateAsync(SubjectEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<SubjectEntity> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SubjectEntity>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(SubjectEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
