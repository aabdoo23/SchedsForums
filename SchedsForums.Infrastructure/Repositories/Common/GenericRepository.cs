using Microsoft.EntityFrameworkCore;
using SchedsForums.Interface;
using SchedsForums.Persistence.Contexts;


namespace SchedsForums.Infrastructure.Repositories.Common
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IBaseEntity
    {
        //TODO: solve referencing issue and throw custom exception

        private readonly ForumsDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(ForumsDbContext context)
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
            var entity = await _dbSet.FindAsync(id)?? throw new NullReferenceException($"Can't find an entity with this Id: {id}.");
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
            return await _dbSet.FindAsync(id) ?? throw new NullReferenceException($"Can't find an entity with this Id: {id}.");
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
