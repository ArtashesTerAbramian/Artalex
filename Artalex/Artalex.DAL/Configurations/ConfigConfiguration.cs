using Artalex.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artalex.DAL.Configurations;

public class ConfigConfiguration : BaseConfiguration<Config>
{
    public override void Configure(EntityTypeBuilder<Config> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("Configs");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(c => c.Value)
            .IsRequired()
            .HasColumnType("text");

        builder.Property(c => c.Description)
            .HasColumnType("text");
    }
}