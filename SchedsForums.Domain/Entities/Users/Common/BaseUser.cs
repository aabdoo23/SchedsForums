using SchedsForums.Domain.Entities.Common;
using SchedsForums.Domain.Entities.Forums.Common;

namespace SchedsForums.Domain.Entities.Users.Common
{
    public abstract class BaseUser : AuditableEntity
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public virtual ICollection<BaseForum> SubscribedForums { get; set; }
    }
}