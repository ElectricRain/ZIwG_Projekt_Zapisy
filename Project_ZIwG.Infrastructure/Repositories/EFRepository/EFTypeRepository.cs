using Microsoft.EntityFrameworkCore;
using Project_ZIwG.Infrastructure.Entities;
using Project_ZIwG.Infrastructure.Repositories.Interfaces;

namespace Project_ZIwG.Infrastructure.Repositories.EFRepository
{
    public class EFTypeRepository : EFGenericRepository<TypeEntity>, ITypeRepository
    {
        public EFTypeRepository(DbContext context) : base(context) { }
    }
}
