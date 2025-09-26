using Artalex.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artalex.DAL.Configurations;

public class AuditQuestionPotentialGroundConfiguration : BaseConfiguration<AuditQuestionPotentialGround>
{
    public override void Configure(EntityTypeBuilder<AuditQuestionPotentialGround> builder)
    {
        base.Configure(builder);

        // Table & Key
        builder.ToTable("AuditQuestionPotentialGrounds");
        builder.HasKey(p => p.Id);

        // Properties
        builder.Property(p => p.Text)
            .IsRequired()
            .HasColumnType("text");

        builder.Property(p => p.AuditQuestionId)
            .IsRequired();

        // Relationships
        builder.HasOne(p => p.AuditQuestion)
            .WithMany(q => q.PotentialGrounds)
            .HasForeignKey(p => p.AuditQuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}