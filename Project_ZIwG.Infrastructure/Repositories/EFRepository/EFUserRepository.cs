using Microsoft.EntityFrameworkCore;
using Project_ZIwG.Infrastructure.Entities;
using Project_ZIwG.Infrastructure.Repositories.Interfaces;
using System.Linq;

namespace Project_ZIwG.Infrastructure.Repositories.EFRepository
{
    public class EFUserRepository : EFGenericRepository<UserEntity>, IUserRepository
    {
        private readonly DbContext _dbContext;

        public EFUserRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public UserEntity GetByUsername(string username)
        {
            var user = _dbContext.Set<UserEntity>().Where(e => e.Name == username).FirstOrDefault();
            return user;
        }
    }
}
