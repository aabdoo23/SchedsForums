using Microsoft.EntityFrameworkCore;
using SchedsForums.Domain.Entities;
using SchedsForums.Domain.Entities.Common;
using SchedsForums.Domain.Entities.Forums;
using SchedsForums.Domain.Entities.Forums.Common;
using SchedsForums.Domain.Entities.Users;
using SchedsForums.Domain.Entities.Users.Common;
namespace SchedsForums.Infrastructure.Contexts
{
    public class SchedsForumsDbContext(DbContextOptions<SchedsForumsDbContext> options) : DbContext(options)
    {
        public DbSet<BaseUser> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Moderator> Moderators { get; set; }
        public DbSet<PendingModerator> PendingModerators { get; set; }
        
        public DbSet<Course> Courses { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<BaseForum> Forums { get; set; }
        public DbSet<GeneralForum> GeneralForums { get; set; }
        public DbSet<CourseForum> CourseForums { get; set; }
        public DbSet<MajorForum> MajorForums { get; set; }
        public DbSet<FacultyForum> FacultyForums { get; set; }

        public DbSet<ForumRequest> ForumRequests { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SchedsForumsDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            SetTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void SetTimestamps()
        {
            var entries = ChangeTracker.Entries<AuditableEntity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
            }
        }
    }
}
