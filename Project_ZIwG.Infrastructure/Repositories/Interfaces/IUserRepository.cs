using Project_ZIwG.Infrastructure.Entities;
using System.Collections.Generic;

namespace Project_ZIwG.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        UserEntity GetByUsername(string username);

        List<RolesEntity> GetRoles(string userId);
    }
}
