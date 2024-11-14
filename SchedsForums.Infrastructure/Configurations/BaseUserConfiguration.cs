using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchedsForums.Domain.Entities.Users;
using SchedsForums.Domain.Entities.Users.Common;

namespace SchedsForums.Infrastructure.Configurations
{
    public class BaseUserConfiguration : IEntityTypeConfiguration<BaseUser>
    {
        public void Configure(EntityTypeBuilder<BaseUser> builder)
        {
            builder
                .HasDiscriminator<string>("UserType")
                .HasValue<Student>(nameof(Student))
                .HasValue<Admin>(nameof(Admin))
                .HasValue<Moderator>(nameof(Moderator))
                .HasValue<PendingModerator>(nameof(PendingModerator));
        }
    }
}
