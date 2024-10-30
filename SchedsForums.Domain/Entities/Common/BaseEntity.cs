namespace SchedsForums.Domain.Entities.Common
{
    public abstract class BaseEntity 
    {
        public Guid Id { get; protected set; }
    }
}
