namespace SchedsForums.Domain.Interfaces
{
    public interface IBaseEntity
    {
        string Id { get; }
        DateTime CreatedAt { get; }
        DateTime UpdatedAt { get; }
    }
}
