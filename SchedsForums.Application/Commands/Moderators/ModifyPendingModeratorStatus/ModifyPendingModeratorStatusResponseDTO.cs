using SchedsForums.Application.Commands.Common;
using SchedsForums.Domain.Entities.Users.Common;

namespace SchedsForums.Application.Commands.Moderators.ModifyPendingModeratorStatus
{
    public class ModifyPendingModeratorStatusResponseDTO : BaseResponseDTO
    {
        public ModeratorStatus Status { get; set; }
        public bool IsSuccess { get; set; }
    }
}
