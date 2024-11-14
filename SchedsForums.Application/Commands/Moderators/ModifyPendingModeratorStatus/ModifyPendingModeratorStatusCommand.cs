using MediatR;
using SchedsForums.Domain.Entities.Users.Common;

namespace SchedsForums.Application.Commands.Moderators.ModifyPendingModeratorStatus
{
    public class ModifyPendingModeratorStatusCommand : IRequest<ModifyPendingModeratorStatusResponseDTO>
    {
        public Guid ModeratorId { get; set; }
        public ModeratorStatus Status { get; set; }
    }
}
