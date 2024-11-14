using SchedsForums.Domain.Entities.Forums.Common;

namespace SchedsForums.Domain.Entities.Forums
{
    public class CourseForum : BaseForum
    {
        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
