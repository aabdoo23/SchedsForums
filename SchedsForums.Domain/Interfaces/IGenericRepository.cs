namespace SchedsForums.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : IBaseEntity
    {
        Task<T> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(string id);

    }
}
