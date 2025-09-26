using Artalex.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artalex.DAL.Configurations;

public class AuditTypeConfiguration : BaseConfiguration<AuditType>
{
    public override void Configure(EntityTypeBuilder<AuditType> builder)
    {
        base.Configure(builder);

        // Table & Key
        builder.ToTable("AuditTypes");
        builder.HasKey(t => t.Id);

        // Properties
        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100);

        // Relationships
        builder.HasMany(t => t.Chapters)
            .WithOne(c => c.AuditType)
            .HasForeignKey(c => c.AuditTypeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}