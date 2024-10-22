using Microsoft.EntityFrameworkCore;
using SchedsForums.Domain.Interfaces;
using SchedsForums.Infrastructure.Contexts;


namespace SchedsForums.Infrastructure.Repositories.Common
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IBaseEntity
    {
        private readonly SchedsForumsDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(SchedsForumsDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<T> InsertAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(string id)
        {
            var entity = Activator.CreateInstance<T>();
            entity.GetType().GetProperty("Id")?.SetValue(entity, id); //TODO: because interface// should i inherit the baseEntity class instead and make its set property public?
            _dbSet.Attach(entity);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id); //looks bad returning null
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
