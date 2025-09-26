using Artalex.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artalex.DAL.Configurations;

public class AuditResponsePotentialGroundConfiguration : BaseConfiguration<AuditResponsePotentialGround>
{
    public override void Configure(EntityTypeBuilder<AuditResponsePotentialGround> builder)
    {
        base.Configure(builder);

        // Table & Key
        builder.ToTable("AuditResponsePotentialGrounds");
        builder.HasKey(pg => pg.Id);

        // Properties
        builder.Property(pg => pg.Text)
            .IsRequired()
            .HasColumnType("text")
            .HasMaxLength(100);
    }   
}