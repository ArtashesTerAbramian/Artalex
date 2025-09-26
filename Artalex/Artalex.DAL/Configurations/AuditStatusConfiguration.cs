using Artalex.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artalex.DAL.Configurations;

public class AuditStatusConfiguration : BaseConfiguration<AuditStatus>
{
    public override void Configure(EntityTypeBuilder<AuditStatus> builder)
    {
        base.Configure(builder);

        // Table & Key
        builder.ToTable("AuditStatus");
        builder.HasKey(s => s.Id);

        // Properties
        builder.Property(s => s.StatusName)
            .IsRequired()
            .HasMaxLength(100);
    }
}