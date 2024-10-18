using SchedsForums.Domain.Entities;
using SchedsForums.Domain.Interfaces.Repositories;
using SchedsForums.Infrastructure.Contexts;
using SchedsForums.Infrastructure.Repositories.Common;

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
