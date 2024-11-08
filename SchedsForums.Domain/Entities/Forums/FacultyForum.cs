using SchedsForums.Domain.Entities.Forums.Common;

namespace SchedsForums.Domain.Entities.Forums
{
    public class FacultyForum : BaseForum
    {
        public Guid FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
    }
}
