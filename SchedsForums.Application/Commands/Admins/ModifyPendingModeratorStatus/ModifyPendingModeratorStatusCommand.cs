using MediatR;
using SchedsForums.Domain.Entities.Users;

namespace SchedsForums.Application.Commands.Admins.ModifyPendingModeratorStatus
{
    public class ModifyPendingModeratorStatusCommand : IRequest<ModifyPendingModeratorStatusResponseDTO>
    {
        public Guid ModeratorId { get; set; }
        public ModeratorStatus Status { get; set; }
    }
}
