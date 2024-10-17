using Microsoft.EntityFrameworkCore;

namespace SchedsForums.Persistence.Contexts
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class ForumsDbContext : DbContext
    {
        public ForumsDbContext(DbContextOptions<ForumsDbContext> options) : base(options)
        {
        }
        public DbSet<BaseEntity> BaseEntities { get; set; }

    }
}
