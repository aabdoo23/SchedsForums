using Microsoft.EntityFrameworkCore;
using SchedsForums.Domain.Entities;
using SchedsForums.Domain.Entities.Common;
using SchedsForums.Domain.Entities.Users;
namespace SchedsForums.Infrastructure.Contexts
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
                .HasValue<Admin>("Admin")
                .HasValue<Student>("Student")
                .HasValue<Moderator>("Moderator");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<BaseUser> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Moderator> Moderators { get; set; }


        public DbSet<Major> Majors { get; set; }

    }
}
