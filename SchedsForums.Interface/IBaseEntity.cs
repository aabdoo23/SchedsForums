namespace SchedsForums.Interface
{
    public interface IBaseEntity
    {
        string Id { get; }
        DateTime CreatedAt { get; }
        DateTime UpdatedAt { get; }
    }
}
