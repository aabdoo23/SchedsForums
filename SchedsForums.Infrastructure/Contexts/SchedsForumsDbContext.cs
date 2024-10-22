using Microsoft.EntityFrameworkCore;
using SchedsForums.Domain.Entities.Common;
using SchedsForums.Domain.Entities.Users;
namespace SchedsForums.Infrastructure.Contexts
{
    public class SchedsForumsDbContext(DbContextOptions<SchedsForumsDbContext> options) : DbContext(options)
    {
        public DbSet<BaseUser> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Moderator> Moderators { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SchedsForumsDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }   
    }
}
