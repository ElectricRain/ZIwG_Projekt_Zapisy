using Project_ZIwG.Infrastructure.Entities;

namespace Project_ZIwG.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        UserEntity GetByUsername(string username);
    }
}
