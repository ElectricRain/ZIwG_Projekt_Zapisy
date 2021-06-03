using Microsoft.EntityFrameworkCore;
using Project_ZIwG.Infrastructure.Entities;
using Project_ZIwG.Infrastructure.Repositories.Interfaces;

namespace Project_ZIwG.Infrastructure.Repositories.EFRepository
{
    public class EFUserRolesRepository : EFGenericRepository<UserRolesEntity>, IUserRolesRepository
    {
        public EFUserRolesRepository(DbContext context) : base(context) { }
    }
}
