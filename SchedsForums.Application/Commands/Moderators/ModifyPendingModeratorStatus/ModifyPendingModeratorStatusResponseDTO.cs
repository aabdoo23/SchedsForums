using SchedsForums.Domain.Entities.Users;

namespace SchedsForums.Application.Commands.Moderators.ModifyPendingModeratorStatus
{
    public class ModifyPendingModeratorStatusResponseDTO
    {
        public string ModeratorId { get; set; }
        public ModeratorStatus Status { get; set; }
        public bool IsSuccess { get; set; }
    }
}
