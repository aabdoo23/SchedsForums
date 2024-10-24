using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchedsForums.Domain.Entities;
using SchedsForums.Domain.Entities.Forums;

namespace SchedsForums.Infrastructure.Configurations
{
    public class FacultyConfiguration : IEntityTypeConfiguration<Faculty>
    {
        public void Configure(EntityTypeBuilder<Faculty> builder)
        {
            builder
                .HasOne(f => f.FacultyForum)
                .WithOne(ff => ff.Faculty)
                .HasForeignKey<FacultyForum>(ff => ff.FacultyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
