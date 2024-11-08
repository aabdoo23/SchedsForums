using SchedsForums.Domain.Entities.Common;
using SchedsForums.Domain.Entities.Users;
using SchedsForums.Domain.Entities.Users.Common;

namespace SchedsForums.Domain.Entities.Forums.Common
{
    public abstract class BaseForum : AuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CreatedById { get; set; }
        public virtual BaseUser CreatedBy { get; set; }
        public virtual IEnumerable<string>? Guidelines { get; set; }
        public virtual ICollection<BaseUser> SubscribedUsers { get; set; }
        public virtual ICollection<Moderator> Moderators { get; set; }
    }
}
