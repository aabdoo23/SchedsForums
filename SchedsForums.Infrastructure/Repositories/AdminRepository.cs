using SchedsForums.Domain.Entities.Users;
using SchedsForums.Infrastructure.Repositories.Common;
using SchedsForums.Interface.Repositories;
using SchedsForums.Persistence.Contexts;

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
