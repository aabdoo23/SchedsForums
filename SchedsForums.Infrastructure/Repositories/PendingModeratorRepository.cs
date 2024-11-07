using Microsoft.EntityFrameworkCore;
using SchedsForums.Application.Interfaces.Repositories;
using SchedsForums.Domain.Entities.Users;
using SchedsForums.Infrastructure.Contexts;
using SchedsForums.Infrastructure.Repositories.Common;

namespace SchedsForums.Infrastructure.Repositories
{
    public class PendingModeratorRepository(SchedsForumsDbContext context) : BaseRepository<PendingModerator>(context), IPendingModeratorRepository
    {
        private readonly SchedsForumsDbContext _context = context 
            ?? throw new ArgumentNullException(nameof(SchedsForumsDbContext));
        public override async Task<IEnumerable<PendingModerator>> GetPaginatedContentAsync(int pageNumber, int pageSize)
        {
            return await _context.PendingModerators
                .Where(pm => !(pm is Moderator))
                .OrderBy(x => x.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public override async Task<int> GetTotalCountAsync()
        {
            return await _context.PendingModerators
                .Where(pm => !(pm is Moderator))
                .CountAsync();
        }

        public override async Task<IEnumerable<PendingModerator>> GetAllAsync()
        {
            return await _context.PendingModerators
                .Where(pm => !(pm is Moderator))
                .ToListAsync();
        }
    }
}
