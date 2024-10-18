using SchedsForums.Domain.Entities.Users;
using SchedsForums.Domain.Interfaces.Repositories;
using SchedsForums.Infrastructure.Contexts;
using SchedsForums.Infrastructure.Repositories.Common;

namespace SchedsForums.Infrastructure.Repositories
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        private readonly ForumsDbContext _context;
        public AdminRepository(ForumsDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
