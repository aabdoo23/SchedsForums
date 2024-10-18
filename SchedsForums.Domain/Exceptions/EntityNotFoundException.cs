namespace SchedsForums.Domain.Exceptions
{
    public class EntityNotFoundException(string name, object key) : Exception($"{name} ({key}) was not found.")
    {
    }
}
