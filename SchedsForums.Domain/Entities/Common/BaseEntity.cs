using SchedsForums.Interface;

namespace SchedsForums.Domain.Entities.Common
{
    public class BaseEntity : IBaseEntity
    {
        public string Id { get; protected set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
