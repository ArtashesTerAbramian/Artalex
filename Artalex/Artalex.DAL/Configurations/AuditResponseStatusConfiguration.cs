using Artalex.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artalex.DAL.Configurations;

public class AuditResponseStatusConfiguration : BaseConfiguration<AuditResponseStatus>
{
    public override void Configure(EntityTypeBuilder<AuditResponseStatus> builder)
    {
        base.Configure(builder);

        // Table & Key
        builder.ToTable("AuditResponseStatus");
        builder.HasKey(s => s.Id);

        // Properties
        builder.Property(s => s.StatusName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(s => s.SetByAuditor)
            .HasDefaultValue(true);

        builder.Property(s => s.SetByManager)
            .HasDefaultValue(false);
    }
}