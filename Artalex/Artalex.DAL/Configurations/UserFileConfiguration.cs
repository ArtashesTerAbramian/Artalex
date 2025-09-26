using Artalex.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artalex.DAL.Configurations;

public class UserFileConfiguration : BaseConfiguration<UserFile>
{
    public override void Configure(EntityTypeBuilder<UserFile> builder)
    {
        base.Configure(builder);

        // Table & Key
        builder.ToTable("UserFiles");
        builder.HasKey(f => f.Id);

        // Properties
        builder.Property(f => f.FileName)
            .IsRequired();

        builder.Property(f => f.FilePath)
            .IsRequired();

        builder.Property(f => f.UserId)
            .IsRequired();

        // Relationships
        builder.HasOne(f => f.User)
            .WithMany(u => u.Files)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}