using SchedsForums.Domain.Entities.Common;

namespace SchedsForums.Domain.Entities
{
    public class Major : AuditableEntity
    {
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public Guid FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
    }
}
