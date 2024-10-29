namespace SchedsForums.Application.Interfaces.Common
{
    public interface IAuditableEntity : IBaseEntity
    {
        DateTime CreatedAt { get; }
        DateTime UpdatedAt { get; }
    }
}