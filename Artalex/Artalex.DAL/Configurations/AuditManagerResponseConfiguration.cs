using Artalex.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artalex.DAL.Configurations;

public class AuditManagerResponseConfiguration : BaseConfiguration<AuditManagerResponse>
{
    public override void Configure(EntityTypeBuilder<AuditManagerResponse> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("AuditManagerResponses");
    }
}