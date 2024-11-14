using SchedsForums.Domain.Entities.Common;

namespace SchedsForums.Domain.Entities
{
    public class Course : AuditableEntity
    {
        public string CourseCode {  get; set; }
        public string CourseName { get; set; }
    }
}
