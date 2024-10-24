using SchedsForums.Domain.Entities.Common;
using SchedsForums.Domain.Entities.Forums;

namespace SchedsForums.Domain.Entities
{
    public class Faculty : BaseEntity
    {
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public virtual IEnumerable<Major>? Majors { get; set; }
        public virtual FacultyForum? FacultyForum { get; set; }
    }
}
