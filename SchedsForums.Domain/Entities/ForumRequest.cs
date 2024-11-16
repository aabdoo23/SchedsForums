using SchedsForums.Domain.Entities.Common;
using SchedsForums.Domain.Entities.Forums.Common;
using SchedsForums.Domain.Entities.Users;
using SchedsForums.Domain.Entities.Users.Common;

namespace SchedsForums.Domain.Entities
{
    public class ForumRequest: AuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Guidelines { get; set; }
        public Guid RequestedById { get; set; }
        public virtual Student RequestedBy { get; set; }
        public string Reason { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public ForumType ForumType { get; set; }
    }
}
