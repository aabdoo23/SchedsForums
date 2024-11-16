using SchedsForums.Domain.Entities.Users.Common;

namespace SchedsForums.Domain.Entities.Users
{
    public class PendingModerator : BaseUser
    {
        public string Reason { get; set; }
        public DateTime? StatusUpdatedAt { get; set; }
        public virtual Admin? StatusUpdatedBy { get; set; }
        public RequestStatus Status { get; set; }
    }
}
