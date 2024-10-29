namespace SchedsForums.Domain.Entities.Common
{
    public class BaseEntity
    {
        public string Id { get; protected set; } = Guid.NewGuid().ToString();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
    }
}
