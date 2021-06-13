using Microsoft.EntityFrameworkCore;
using Project_ZIwG.Infrastructure.Entities;
using Project_ZIwG.Infrastructure.Repositories.Interfaces;

namespace Project_ZIwG.Infrastructure.Repositories.EFRepository
{
    public class EFRolesRepository : EFGenericRepository<RolesEntity>, IRolesRepository
    {
        public EFRolesRepository(DbContext context) : base(context) { }
    }
}
