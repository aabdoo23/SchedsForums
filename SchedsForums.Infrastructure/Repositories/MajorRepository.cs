using SchedsForums.Domain.Entities;
using SchedsForums.Infrastructure.Repositories.Common;
using SchedsForums.Interface.Repositories;
using SchedsForums.Persistence.Contexts;

namespace SchedsForums.Infrastructure.Repositories
{
    public class MajorRepository : GenericRepository<Major>, IMajorRepository
    {
        private readonly ForumsDbContext _context;
        public MajorRepository(ForumsDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
