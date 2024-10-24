using SchedsForums.Domain.Entities.Common;

namespace SchedsForums.Application.Interfaces.Common
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<bool> ExistsAsync(string id);
        Task<T?> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(string id);
    }
}
