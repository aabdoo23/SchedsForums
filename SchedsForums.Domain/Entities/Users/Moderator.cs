using SchedsForums.Domain.Entities.Forums.Common;

namespace SchedsForums.Domain.Entities.Users
{
    public class Moderator : PendingModerator
    {
        public virtual ICollection<BaseForum> ModeratedForums { get; set; }
    }
}
