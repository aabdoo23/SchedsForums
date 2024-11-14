using SchedsForums.Application.Interfaces.Common;
using SchedsForums.Application.Interfaces.Repositories;
using SchedsForums.Application.Interfaces.Services;
using SchedsForums.Domain.Entities.Users;
using SchedsForums.Infrastructure.Contexts;

namespace SchedsForums.Infrastructure.Services
{
    public class PendingModeratorService(IPendingModeratorRepository pendingModeratorRepository,
        ICurrentUserService currentUserService,
        IBaseRepository<Admin> adminRepository,
        SchedsForumsDbContext context)
    {
        private readonly IPendingModeratorRepository _pendingModeratorRepository = pendingModeratorRepository
            ?? throw new ArgumentNullException(nameof(IPendingModeratorRepository));
        private readonly ICurrentUserService _currentUserService = currentUserService
            ?? throw new ArgumentNullException(nameof(ICurrentUserService));
        private readonly SchedsForumsDbContext _context = context
            ?? throw new ArgumentNullException(nameof(SchedsForumsDbContext));
        private readonly IBaseRepository<Admin> _adminRepository = adminRepository
            ?? throw new ArgumentNullException(nameof(IBaseRepository<Admin>));
        public async Task PromoteToModeratorAsync(Guid pendingModeratorId)
        {
            var pendingModerator = await _pendingModeratorRepository.GetByIdAsync(pendingModeratorId)
                ?? throw new KeyNotFoundException(pendingModeratorId.ToString());

            var adminId = _currentUserService.GetUserId();
            var admin = await _adminRepository.GetByIdAsync(adminId);

            pendingModerator.Status = ModeratorStatus.Approved;
            pendingModerator.StatusUpdatedAt = DateTime.UtcNow;
            pendingModerator.StatusUpdatedBy = admin;

            _context.Entry(pendingModerator).Property("UserType").CurrentValue = nameof(Moderator);

            await _pendingModeratorRepository.UpdateAsync(pendingModerator);
        }
    }
}
