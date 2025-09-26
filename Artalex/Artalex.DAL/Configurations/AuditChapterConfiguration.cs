using Artalex.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artalex.DAL.Configurations;

public class AuditChapterConfiguration : BaseConfiguration<AuditChapter>
{
    public override void Configure(EntityTypeBuilder<AuditChapter> builder)
    {
        base.Configure(builder);

        // Table & Keys
        builder.ToTable("AuditChapters");
        builder.HasKey(ac => ac.Id);

        // Properties
        builder.Property(ac => ac.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ac => ac.AuditTypeId)
            .IsRequired();

        // Relationships
        builder.HasOne(ac => ac.AuditType)
            .WithMany() // Assuming AuditType does not have a collection of Chapters
            .HasForeignKey(ac => ac.AuditTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(ac => ac.Questions)
            .WithOne(q => q.AuditChapter) // Assuming AuditQuestion has navigation to AuditChapter
            .HasForeignKey(q => q.AuditChapterId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}