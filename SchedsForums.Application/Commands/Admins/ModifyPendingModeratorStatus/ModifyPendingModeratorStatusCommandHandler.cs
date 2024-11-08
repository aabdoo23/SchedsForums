using MediatR;
using SchedsForums.Application.Interfaces.Common;
using SchedsForums.Application.Interfaces.Repositories;
using SchedsForums.Application.Interfaces.Services;
using SchedsForums.Domain.Entities.Users;
using SchedsForums.Domain.Entities.Users.Common;

namespace SchedsForums.Application.Commands.Admins.ModifyPendingModeratorStatus
{
    public class ModifyPendingModeratorStatusCommandHandler(
        ICurrentUserService currentUserService,
        IPendingModeratorRepository pendingModeratorRepository,
        IBaseRepository<Moderator> moderatorRepository,
        IBaseRepository<Admin> adminRepository) : 
        IRequestHandler<ModifyPendingModeratorStatusCommand, ModifyPendingModeratorStatusResponseDTO>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService
            ?? throw new ArgumentNullException(nameof(currentUserService));
        private readonly IPendingModeratorRepository _pendingModeratorRepository = pendingModeratorRepository
            ?? throw new ArgumentNullException(nameof(pendingModeratorRepository));
        private readonly IBaseRepository<Moderator> _moderatorRepository = moderatorRepository
            ?? throw new ArgumentNullException(nameof(moderatorRepository));
        private readonly IBaseRepository<Admin> _adminRepository = adminRepository
            ?? throw new ArgumentNullException(nameof(adminRepository));

        public async Task<ModifyPendingModeratorStatusResponseDTO> Handle(
            ModifyPendingModeratorStatusCommand request, 
            CancellationToken cancellationToken)
        {
            var adminId = _currentUserService.GetUserId();
            var admin = await _adminRepository.GetByIdAsync(adminId);
            var pendingModerator = await _pendingModeratorRepository.GetByIdAsync(request.ModeratorId)
                ?? throw new KeyNotFoundException(nameof(request.ModeratorId));

            pendingModerator.Status = request.Status;
            pendingModerator.StatusUpdatedAt = DateTime.UtcNow;
            pendingModerator.StatusUpdatedBy = admin;

            if (request.Status == ModeratorStatus.Approved)
            {
                var moderator = new Moderator
                {
                    Name = pendingModerator.Name,
                    Username = pendingModerator.Username,
                    Email = pendingModerator.Email,
                    PasswordHash = pendingModerator.PasswordHash,
                    Status = ModeratorStatus.Approved,
                    CreatedAt = pendingModerator.CreatedAt,
                    StatusUpdatedAt = DateTime.UtcNow,
                    StatusUpdatedBy = admin,
                    Reason = pendingModerator.Reason   
                };
                await _moderatorRepository.InsertAsync(moderator);
                await _pendingModeratorRepository.DeleteAsync(pendingModerator.Id);
            }
            else
            {
                await _pendingModeratorRepository.UpdateAsync(pendingModerator);
            }
            return new ModifyPendingModeratorStatusResponseDTO
            {
                Id = pendingModerator.Id,
                IsSuccess = true,
                Status = pendingModerator.Status
            };
        }
    }
}
