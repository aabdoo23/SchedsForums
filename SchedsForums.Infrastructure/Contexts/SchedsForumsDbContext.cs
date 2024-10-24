using Microsoft.EntityFrameworkCore;
using SchedsForums.Domain.Entities;
using SchedsForums.Domain.Entities.Common;
using SchedsForums.Domain.Entities.Forums;
using SchedsForums.Domain.Entities.Users;
namespace SchedsForums.Infrastructure.Contexts
{
    public class SchedsForumsDbContext(DbContextOptions<SchedsForumsDbContext> options) : DbContext(options)
    {
        public DbSet<BaseUser> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Moderator> Moderators { get; set; }

        public DbSet<BaseForum> Forums { get; set; }
        public DbSet<GeneralForum> GeneralForums { get; set; }
        public DbSet<CourseForum> CourseForums { get; set; }
        public DbSet<MajorForum> MajorForums { get; set; }
        public DbSet<FacultyForum> FacultyForums { get; set; }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Faculty> Faculties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SchedsForumsDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }   
    }
}
