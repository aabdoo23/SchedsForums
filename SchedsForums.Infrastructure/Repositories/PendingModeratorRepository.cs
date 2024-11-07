using Microsoft.EntityFrameworkCore;
using SchedsForums.Application.Interfaces.Repositories;
using SchedsForums.Application.Queries.Common.DTOs;
using SchedsForums.Application.Queries.PendingModerators.DTOs;
using SchedsForums.Domain.Entities.Users;
using SchedsForums.Infrastructure.Contexts;
using SchedsForums.Infrastructure.Repositories.Common;

namespace SchedsForums.Infrastructure.Repositories
{
    public class PendingModeratorRepository(SchedsForumsDbContext context) : BaseRepository<PendingModerator>(context), IPendingModeratorRepository
    {
        private readonly SchedsForumsDbContext _context = context
            ?? throw new ArgumentNullException(nameof(SchedsForumsDbContext));
        public async Task<BaseGetPaginatedResponseDTO<BasePendingModeratorResponseDTO>> GetPaginatedPendingModeratorsAsync(int pageNumber, int pageSize)
        {
            var queryable = _context.PendingModerators
                .Where(pm => !(pm is Moderator));

            var entityResponse = await base.GetPaginatedContentAsync(queryable, pageNumber, pageSize);
            return new BaseGetPaginatedResponseDTO<BasePendingModeratorResponseDTO>
            {
                Data = entityResponse.Data.Select(pm => new BasePendingModeratorResponseDTO(pm)),
                ReturnedCount = entityResponse.ReturnedCount,
                TotalCount = entityResponse.TotalCount,
                PageNumber = entityResponse.PageNumber,
                PageSize = entityResponse.PageSize
            };
        }

        public override async Task<IEnumerable<PendingModerator>> GetAllAsync()
        {
            return await _context.PendingModerators
                .Where(pm => !(pm is Moderator))
                .ToListAsync();
        }
    }
}
