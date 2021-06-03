using Microsoft.EntityFrameworkCore;
using Project_ZIwG.Infrastructure.Entities;
using Project_ZIwG.Infrastructure.Repositories.Interfaces;

namespace Project_ZIwG.Infrastructure.Repositories.EFRepository
{
    public class EFUserSubjectRepository : EFGenericRepository<UserSubjectEntity>, IUserSubjectRepository
    {
        public EFUserSubjectRepository(DbContext context) : base(context) { }
    }
}
