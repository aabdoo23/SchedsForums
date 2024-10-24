using SchedsForums.Domain.Entities.Common;

namespace SchedsForums.Domain.Entities
{
    public class Course : BaseEntity
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string? Description { get; set; }
    }
}
