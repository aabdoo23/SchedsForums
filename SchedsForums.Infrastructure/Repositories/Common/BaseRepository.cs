using Microsoft.EntityFrameworkCore;
using SchedsForums.Application.Interfaces.Common;
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

        public async Task DeleteAsync(string id)
        {
            await _dbSet.Where(e => e.Id.ToString() == id).ExecuteDeleteAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> GetTotalCount()
        {
            return await _dbSet.CountAsync();
        }

        public async Task<IEnumerable<T>> GetFromTo(int pageNumber, int pageSize)
        {
            return await _dbSet
                .AsNoTracking() //is this necessary?
                .OrderBy(x => x.Id) //by updatedAt better?
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
