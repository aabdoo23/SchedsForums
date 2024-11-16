using SchedsForums.Application.Interfaces.Common;
using SchedsForums.Application.Interfaces.Repositories;
using SchedsForums.Application.Interfaces.Services;
using SchedsForums.Application.Queries.Common.DTOs;
using SchedsForums.Application.Queries.PendingModerators.DTOs;
using SchedsForums.Domain.Entities.Users;
using SchedsForums.Domain.Entities.Users.Common;
using SchedsForums.Infrastructure.Contexts;
using SchedsForums.Infrastructure.Repositories.Common;

namespace SchedsForums.Infrastructure.Repositories
{
    public class PendingModeratorRepository(
            ICurrentUserService currentUserService,
            IBaseRepository<Admin> adminRepository,
            SchedsForumsDbContext context) 
        : BaseRepository<PendingModerator>(context), IPendingModeratorRepository
    {
        private readonly ICurrentUserService _currentUserService = currentUserService
            ?? throw new ArgumentNullException(nameof(ICurrentUserService));
        private readonly SchedsForumsDbContext _context = context
            ?? throw new ArgumentNullException(nameof(SchedsForumsDbContext));
        private readonly IBaseRepository<Admin> _adminRepository = adminRepository
            ?? throw new ArgumentNullException(nameof(IBaseRepository<Admin>));

        public async Task<PaginatedResponseDTO<BasePendingModeratorResponseDTO>> GetPaginatedPendingModeratorsAsync(int pageNumber, int pageSize)
        {
            var queryable = _context.PendingModerators
                .Where(pm => !(pm is Moderator));

            var entityResponse = await base.GetPaginatedContentAsync(queryable, pageNumber, pageSize);
            return new PaginatedResponseDTO<BasePendingModeratorResponseDTO>
            {
                Data = entityResponse.Data.Select(pm => new BasePendingModeratorResponseDTO(pm)).ToList(),
                TotalCount = entityResponse.TotalCount,
                PageNumber = entityResponse.PageNumber,
                PageSize = entityResponse.PageSize
            };
        }
        public async Task PromoteToModeratorAsync(Guid pendingModeratorId)
        {
            var pendingModerator = await GetByIdAsync(pendingModeratorId)
                ?? throw new KeyNotFoundException(pendingModeratorId.ToString());

            var adminId = _currentUserService.GetUserId();
            var admin = await _adminRepository.GetByIdAsync(adminId);

            pendingModerator.Status = RequestStatus.Approved;
            pendingModerator.StatusUpdatedAt = DateTime.UtcNow;
            pendingModerator.StatusUpdatedBy = admin;

            _context.Entry(pendingModerator).Property("UserType").CurrentValue = nameof(Moderator);

            await UpdateAsync(pendingModerator);
        }
    }
}
