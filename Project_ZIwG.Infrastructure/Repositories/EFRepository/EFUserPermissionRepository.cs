using Microsoft.EntityFrameworkCore;
using Project_ZIwG.Infrastructure.Entities;
using Project_ZIwG.Infrastructure.Repositories.Interfaces;

namespace Project_ZIwG.Infrastructure.Repositories.EFRepository
{
    public class EFUserPermissionRepository : EFGenericRepository<UserPermissionEntity>, IUserPermissionRepository
    {
        public EFUserPermissionRepository(DbContext context) : base(context) { }
    }
}