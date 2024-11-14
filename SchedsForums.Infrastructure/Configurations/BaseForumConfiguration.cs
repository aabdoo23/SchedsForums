using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchedsForums.Domain.Entities.Forums;
using SchedsForums.Domain.Entities.Forums.Common;

namespace SchedsForums.Infrastructure.Configurations
{
    public class BaseForumConfiguration : IEntityTypeConfiguration<BaseForum>
    {
        public void Configure(EntityTypeBuilder<BaseForum> builder)
        {
            builder
                .HasDiscriminator<string>("ForumType")
                .HasValue<GeneralForum>(nameof(GeneralForum))
                .HasValue<CourseForum>(nameof(CourseForum))
                .HasValue<FacultyForum>(nameof(FacultyForum))
                .HasValue<MajorForum>(nameof(MajorForum));

            builder
                .HasOne(f => f.CreatedBy)
                .WithMany()
                .HasForeignKey(f => f.CreatedById);

            builder
                .HasMany(f => f.SubscribedUsers)
                .WithMany(u => u.SubscribedForums)
                .UsingEntity(join => join.ToTable("ForumSubscriptions"));

            builder
                .HasMany(f => f.Moderators)
                .WithMany(m => m.ModeratedForums)
                .UsingEntity(join => join.ToTable("ForumModerators"));
        }
    }
}
