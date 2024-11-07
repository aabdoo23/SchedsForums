using SchedsForums.Application.Queries.Common.DTOs;
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
        Task<BaseGetPaginatedEntityDTO<T>> GetPaginatedContentAsync(IQueryable<T> queryable, int pageNumber, int pageSize);
    }
}
