using Microsoft.EntityFrameworkCore;
using SchedsForums.Application.Interfaces;
using SchedsForums.Domain.Entities;
using SchedsForums.Domain.Entities.Users;
using SchedsForums.Infrastructure.Contexts;
using SchedsForums.Infrastructure.Repositories.Common;

namespace SchedsForums.Infrastructure.Repositories
{
    public class PendingModeratorRepository(SchedsForumsDbContext context) : BaseRepository<PendingModerator>(context), IPendingModeratorRepository
    {
        private readonly SchedsForumsDbContext _context = context ?? throw new ArgumentNullException(nameof(SchedsForumsDbContext));
        public async Task<IEnumerable<PendingModerator>> GetFromTo(int start, int end)
        {
            return await _context.PendingModerators
                .Skip(start)
                .Take(end - start)
                .ToListAsync();
        }
    }
}
