using SchedsForums.Application.Interfaces.Common.DTOs;
using SchedsForums.Domain.Entities.Users;

namespace SchedsForums.Application.Queries.PendingModerators.DTOs
{
    public class BasePendingModeratorResponseDTO : BaseResponseDTO
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Reason { get; set; }
    
        public BasePendingModeratorResponseDTO(PendingModerator moderator)
        {
            Id = moderator.Id;
            FullName = moderator.Name;
            UserName = moderator.Username;
            Email = moderator.Email;
            Reason = moderator.Reason;
        }
    }
}
