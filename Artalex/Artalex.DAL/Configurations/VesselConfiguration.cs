using Artalex.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artalex.DAL.Configurations;

public class VesselConfiguration : BaseConfiguration<Vessel>
{
    public override void Configure(EntityTypeBuilder<Vessel> builder)
    {
        base.Configure(builder);

        // Table & Key
        builder.ToTable("Vessels");
        builder.HasKey(v => v.Id);

        // Properties
        builder.Property(v => v.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(v => v.IMO)
            .IsRequired()
            .HasMaxLength(7);

        builder.Property(v => v.LastAuditDate);

        builder.Property(v => v.NextAuditDate);

        builder.Property(v => v.LastAuditorName)
            .HasMaxLength(100);

        builder.Property(v => v.Email)
            .HasMaxLength(256); // Email max length (adjust if needed)

        // Relationships
        builder.HasMany(v => v.Files)
            .WithOne(f => f.Vessel)
            .HasForeignKey(f => f.VesselId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}