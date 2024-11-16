using SchedsForums.Application.Interfaces.Common.DTOs;
using SchedsForums.Domain.Entities.Users.Common;

namespace SchedsForums.Application.Commands.Moderators.ModifyPendingModeratorStatus
{
    public class ModifyPendingModeratorStatusResponseDTO : BaseIdResponseDTO
    {
        public RequestStatus Status { get; set; }
        public bool IsSuccess { get; set; }
    }
}
