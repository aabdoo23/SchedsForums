using SchedsForums.Domain.Entities.Common;

namespace SchedsForums.Domain.Entities.Forums
{
    public class FacultyForum : BaseForum
    {
        public string FacultyId { get; set; }
        public virtual Faculty? Faculty { get; set; }
    }
}
