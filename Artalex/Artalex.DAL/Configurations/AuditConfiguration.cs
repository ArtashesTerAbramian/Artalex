using Artalex.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artalex.DAL.Configurations;

public class AuditConfiguration : BaseConfiguration<Audit>
{
    public override void Configure(EntityTypeBuilder<Audit> builder)
    {
        base.Configure(builder);

        // Table & Keys
        builder.ToTable("Audits");
        builder.HasKey(a => a.Id);

        // Relationships
        builder.HasOne(a => a.Auditor)
            .WithMany()
            .HasForeignKey(a => a.AuditorUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Vessel)
            .WithMany()
            .HasForeignKey(a => a.VesselId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.AuditStatus)
            .WithMany()
            .HasForeignKey(a => a.AuditStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.AuditType)
            .WithMany()
            .HasForeignKey(a => a.AuditTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(a => a.Responses)
            .WithOne(r => r.Audit)
            .HasForeignKey(r => r.AuditId)
            .OnDelete(DeleteBehavior.Cascade);

        // Properties
        builder.Property(a => a.MasterName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.PortAgentName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.PortAgentPhone)
            .HasMaxLength(20);

        builder.Property(a => a.PortAgentEmail)
            .HasMaxLength(100);

        builder.Property(a => a.EmbarkationPort)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.DisembarkationPort)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.Comment)
            .HasColumnType("text");

        builder.Property(a => a.AuditDate)
            .IsRequired();
    }
}