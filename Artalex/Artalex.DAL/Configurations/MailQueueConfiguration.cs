using Artalex.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artalex.DAL.Configurations;

public class MailQueueConfiguration : BaseConfiguration<MailQueue>
{
    public override void Configure(EntityTypeBuilder<MailQueue> builder)
    {
        base.Configure(builder);

        // Table & Keys
        builder.ToTable("MailQueues");
        builder.HasKey(m => m.Id);

        // Relationships
        builder.HasOne(m => m.User)
            .WithMany() // Assuming User does not have a collection of MailQueues. If it does, replace with .WithMany(u => u.MailQueues)
            .HasForeignKey(m => m.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Properties
        builder.Property(m => m.Subject)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(m => m.Text)
            .IsRequired()
            .HasColumnType("text");

        builder.Property(m => m.Contact)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(m => m.IsSent)
            .IsRequired();

        builder.Property(m => m.FailedCount)
            .IsRequired();
    }
}