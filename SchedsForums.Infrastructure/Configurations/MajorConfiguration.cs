using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchedsForums.Domain.Entities;
using SchedsForums.Domain.Entities.Forums;

namespace SchedsForums.Infrastructure.Configurations
{
    public class MajorConfiguration : IEntityTypeConfiguration<Major>
    {
        public void Configure(EntityTypeBuilder<Major> builder)
        {
            builder
                .HasOne(f => f.MajorForum)
                .WithOne(ff => ff.Major)
                .HasForeignKey<MajorForum>(ff => ff.MajorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
