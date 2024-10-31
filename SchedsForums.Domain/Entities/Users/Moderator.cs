using SchedsForums.Domain.Entities.Common;

namespace SchedsForums.Domain.Entities.Users
{
    public class Moderator : BaseUser
    {
        public virtual ModeratorSignUpRequest ModeratorSignUpRequest { get; set; }
        public virtual Admin ApprovedBy { get; set; }
    }
}
