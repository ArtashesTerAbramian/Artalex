using Artalex.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artalex.DAL.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(u => u.Surname)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(u => u.Messenger)
            .HasMaxLength(256);

        builder.Property(u => u.MessengerPhoneNumber)
            .HasMaxLength(50);

        builder.Property(u => u.AdditionalInfo)
            .HasMaxLength(250);

        builder.Property(u => u.TenantId);

        builder.HasMany(u => u.Files)
            .WithOne(f => f.User)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Optional: indexes for multi-tenancy and common queries
        // builder.HasIndex(u => u.UserName);
    }
}