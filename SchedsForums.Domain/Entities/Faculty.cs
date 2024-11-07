using SchedsForums.Domain.Entities.Common;

namespace SchedsForums.Domain.Entities
{
    public class Faculty : AuditableEntity
    {
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<Major> Majors { get; set; }
    }
}
