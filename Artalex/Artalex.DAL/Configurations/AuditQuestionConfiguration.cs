using Artalex.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artalex.DAL.Configurations;

public class AuditQuestionConfiguration : BaseConfiguration<AuditQuestion>
{
    public override void Configure(EntityTypeBuilder<AuditQuestion> builder)
    {
        base.Configure(builder);

        // Table & Key
        builder.ToTable("AuditQuestions");
        builder.HasKey(q => q.Id);

        // Properties
        builder.Property(q => q.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(q => q.AuditChapterId)
            .IsRequired();

        builder.Property(q => q.Text)
            .HasColumnType("text");

        builder.Property(q => q.Explanation)
            .HasColumnType("text");

        builder.Property(q => q.ReferenceTo);

        // Relationships
        builder.HasOne(q => q.AuditChapter)
            .WithMany(ac => ac.Questions)
            .HasForeignKey(q => q.AuditChapterId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(q => q.PotentialGrounds)
            .WithOne(pg => pg.AuditQuestion)
            .HasForeignKey(pg => pg.AuditQuestionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(q => q.Responses)
            .WithOne(r => r.AuditQuestion)
            .HasForeignKey(r => r.AuditQuestionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(q => q.AuditManagerResponses)
            .WithOne(mr => mr.AuditQuestion)
            .HasForeignKey(mr => mr.AuditQuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}