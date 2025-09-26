using Artalex.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artalex.DAL.Configurations;

public class VesselFileConfiguration : BaseConfiguration<VesselFile>
{
    public override void Configure(EntityTypeBuilder<VesselFile> builder)
    {
        base.Configure(builder);

        // Table & Key
        builder.ToTable("VesselFiles");
        builder.HasKey(f => f.Id);

        // Properties
        builder.Property(f => f.FileName)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(f => f.FilePath)
            .IsRequired()
            .HasMaxLength(512);

        builder.Property(f => f.VesselId)
            .IsRequired();

        // Relationships
        builder.HasOne(f => f.Vessel)
            .WithMany(v => v.Files)
            .HasForeignKey(f => f.VesselId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}