using SchedsForums.Domain.Entities.Users;
using SchedsForums.Domain.Interfaces.Repositories;
using SchedsForums.Infrastructure.Contexts;
using SchedsForums.Infrastructure.Repositories.Common;

namespace SchedsForums.Infrastructure.Repositories
{
    public class ModeratorRepository : GenericRepository<Moderator>, IModeratorRepository
    {
        private readonly ForumsDbContext _context;
        public ModeratorRepository(ForumsDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
