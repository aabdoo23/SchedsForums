using Microsoft.EntityFrameworkCore;
using SchedsForums.Application.Interfaces.Common;
using SchedsForums.Application.Queries.Common;
using SchedsForums.Domain.Entities.Common;
using SchedsForums.Infrastructure.Contexts;

namespace SchedsForums.Infrastructure.Repositories.Common
{
    public class BaseRepository<T>(SchedsForumsDbContext context) : IBaseRepository<T> where T : BaseEntity
    {
        private readonly SchedsForumsDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly DbSet<T> _dbSet = context.Set<T>();

        public async Task<T> InsertAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _dbSet.Where(e => e.Id == id).ExecuteDeleteAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<int> GetTotalCountAsync()
        {
            return await _dbSet.CountAsync();
        }

        public virtual async Task<IEnumerable<T>> GetPaginatedContentAsync(int pageNumber, int pageSize)
        {
            return await _dbSet
                .OrderBy(x => x.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public virtual async Task<BaseGetPaginatedResponseDTO<T>> GetPaginatedAsync(int pageNumber, int pageSize)
        {
            var totalCount = await GetTotalCountAsync();
            var data = await GetPaginatedContentAsync(pageNumber, pageSize);
            return new BaseGetPaginatedResponseDTO<T>
            {
                Data = data,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount,
                ReturnedCount = data.Count()
            };
        }
    }
}
