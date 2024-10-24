using SchedsForums.Domain.Entities.Users;

namespace SchedsForums.Domain.Entities.Common
{
    public class BaseForum : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatedById { get; set; }
        public virtual BaseUser? CreatedBy { get; set; }
        public virtual IEnumerable<BaseUser>? SubscribedUsers { get; set; }
        public virtual IEnumerable<Moderator>? Moderators { get; set; }
    }
}
