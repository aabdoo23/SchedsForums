using SchedsForums.Application.Commands.Common;
using SchedsForums.Domain.Entities.Users;

namespace SchedsForums.Application.Commands.Admins.ModifyPendingModeratorStatus
{
    public class ModifyPendingModeratorStatusResponseDTO : BaseResponseDTO
    {
        public ModeratorStatus Status { get; set; }
        public bool IsSuccess { get; set; }
    }
}
