using SchedsForums.Domain.Entities.Common;

namespace SchedsForums.Application.Interfaces.Common
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(string id);
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<T>> GetFromTo(int pageNumber, int pageSize);
        Task<int> GetTotalCount();
    }
}
