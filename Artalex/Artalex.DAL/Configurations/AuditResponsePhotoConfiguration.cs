using Artalex.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artalex.DAL.Configurations;

public class AuditResponsePhotoConfiguration : BaseConfiguration<AuditResponsePhoto>
{
    public override void Configure(EntityTypeBuilder<AuditResponsePhoto> builder)
    {
        base.Configure(builder);

        // Table & Key
        builder.ToTable("AuditResponsePhotos");
        builder.HasKey(p => p.Id);

        // Properties
        builder.Property(p => p.FileName)
            .IsRequired();

        builder.Property(p => p.FilePath)
            .IsRequired();

        builder.Property(p => p.AuditResponseId)
            .IsRequired();

        // Relationships
        builder.HasOne(p => p.AuditResponse)
            .WithMany(r => r.Photos) // assuming AuditResponse has a collection called Photos
            .HasForeignKey(p => p.AuditResponseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}