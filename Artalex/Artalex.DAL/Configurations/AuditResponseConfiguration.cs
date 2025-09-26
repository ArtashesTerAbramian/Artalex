using Artalex.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artalex.DAL.Configurations;

public class AuditResponseConfiguration : BaseConfiguration<AuditResponse>
{
    public override void Configure(EntityTypeBuilder<AuditResponse> builder)
    {
        base.Configure(builder);

        builder.ToTable("AuditResponses");
        builder.HasKey(ar => ar.Id);

        builder.Property(ar => ar.AuditResponseDate)
            .IsRequired();

        builder.Property(ar => ar.ResponseText)
            .HasColumnType("text");

        builder.HasOne(ar => ar.AuditResponseStatus)
            .WithMany()
            .HasForeignKey(ar => ar.AuditResponseStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ar => ar.AuditResponseAssignedTo)
            .WithMany()
            .HasForeignKey(ar => ar.AuditResponseAssignedToId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ar => ar.AuditResponsePotentialGround)
            .WithMany()
            .HasForeignKey(ar => ar.AuditResponsePotentialGroundId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ar => ar.AuditQuestionPotentialGround)
            .WithMany()
            .HasForeignKey(ar => ar.AuditResponseQuestionPotentialGroundId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ar => ar.Audit)
            .WithMany(a => a.Responses)
            .HasForeignKey(ar => ar.AuditId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ar => ar.AuditQuestion)
            .WithMany(q => q.Responses)
            .HasForeignKey(ar => ar.AuditQuestionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(ar => ar.Photos)
            .WithOne(p => p.AuditResponse)
            .HasForeignKey(p => p.AuditResponseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}