using Microsoft.EntityFrameworkCore;
using Project_ZIwG.Infrastructure.Entities;
using Project_ZIwG.Infrastructure.Repositories.Interfaces;

namespace Project_ZIwG.Infrastructure.Repositories.EFRepository
{
    public class EFSubjectRepository : EFGenericRepository<SubjectEntity>, ISubjectRepository
    {
        public EFSubjectRepository(DbContext context) : base(context) { }
    }
}
