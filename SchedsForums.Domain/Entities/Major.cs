using SchedsForums.Domain.Entities.Common;
using SchedsForums.Domain.Entities.Forums;

namespace SchedsForums.Domain.Entities
{
    public class Major : BaseEntity
    {
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string? FacultyId { get; set; }
        public virtual Faculty? Faculty { get; set; }
        public virtual IEnumerable<Course>? Courses { get; set; }
        public virtual MajorForum? MajorForum { get; set; }
    }
}
