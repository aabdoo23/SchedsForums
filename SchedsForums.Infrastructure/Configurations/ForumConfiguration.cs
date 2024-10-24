using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchedsForums.Domain.Entities.Common;
using SchedsForums.Domain.Entities.Forums;
using SchedsForums.Domain.Entities.Users;

namespace SchedsForums.Infrastructure.Configurations
{
    public class ForumConfiguration : IEntityTypeConfiguration<BaseForum>
    {
        public void Configure(EntityTypeBuilder<BaseForum> builder)
        {
            builder
                .HasDiscriminator<string>("ForumType")
                .HasValue<GeneralForum>("General")
                .HasValue<CourseForum>("Course")
                .HasValue<FacultyForum>("Faculty")
                .HasValue<MajorForum>("Major");
            builder
                .HasOne(f => f.CreatedBy)
                .WithMany(u => u.CreatedForums)
                .HasForeignKey(f => f.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);
            builder
               .HasMany(f => f.Moderators)
               .WithMany(m => m.ModeratedForums)
               .UsingEntity<Dictionary<string, object>>(
                   "ForumModerators",
                   j => j
                       .HasOne<Moderator>()
                       .WithMany()
                       .HasForeignKey("ModeratorId")
                       .OnDelete(DeleteBehavior.Cascade),
                   j => j
                       .HasOne<BaseForum>()
                       .WithMany()
                       .HasForeignKey("ForumId")
                       .OnDelete(DeleteBehavior.Cascade)
               );
        }
    }
}
