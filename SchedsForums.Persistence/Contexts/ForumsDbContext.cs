using Microsoft.EntityFrameworkCore;
using SchedsForums.Domain.Entities;
using SchedsForums.Domain.Entities.Common;
using SchedsForums.Domain.Entities.Users;
namespace SchedsForums.Persistence.Contexts
{
    public class ForumsDbContext : DbContext
    {
        public ForumsDbContext(DbContextOptions<ForumsDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseUser>()
                .HasDiscriminator<string>("UserType")
                .HasValue<Student>("Student");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<BaseUser> Users { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
