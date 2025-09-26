using Artalex.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artalex.DAL.Configurations;

public class AuditResponseAssignedToConfiguration : BaseConfiguration<AuditResponseAssignedTo>
{ 
    public override void Configure(EntityTypeBuilder<AuditResponseAssignedTo> builder)
    {
        base.Configure(builder);

        // Table & Key
        builder.ToTable("AuditResponseAssignedTos");
        builder.HasKey(a => a.Id);

        // Properties
        builder.Property(a => a.Text)
            .IsRequired()
            .HasMaxLength(100);
    }
    
}