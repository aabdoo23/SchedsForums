
using SchedsForums.Domain.Interfaces;

namespace SchedsForums.Domain.Entities.Common
{
    public class BaseEntity : IBaseEntity
    {
        public string Id { get; protected set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
