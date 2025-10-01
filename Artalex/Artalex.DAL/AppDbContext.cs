using Artalex.DAL.Models;
using Artalex.DAL.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Artalex.DAL;

public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    private readonly IContextModificatorService _contextModificatorService;
    public string TenantName { get; set; }

    public AppDbContext(
        DbContextOptions options, 
        IContextModificatorService contextModificatorService
        ) : base(options)
    {
        _contextModificatorService = contextModificatorService;
    }

    // Domain-specific tables
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<Audit> Audits { get; set; }
    public DbSet<AuditChapter> AuditChapters { get; set; }
    public DbSet<AuditManagerResponse> AuditManagerResponses { get; set; }
    public DbSet<AuditQuestion> AuditQuestions { get; set; }
    public DbSet<AuditQuestionPotentialGround> AuditQuestionPotentialGrounds { get; set; }
    public DbSet<AuditResponse> AuditResponses { get; set; }
    public DbSet<AuditResponseAssignedTo> AuditResponseAssignedTos { get; set; }
    public DbSet<AuditResponsePhoto> AuditResponsePhotos { get; set; }
    public DbSet<AuditResponsePotentialGround> AuditResponsePotentialGrounds { get; set; }
    public DbSet<AuditResponseStatus> AuditResponseStatus { get; set; }
    public DbSet<AuditStatus> AuditStatus { get; set; }
    public DbSet<AuditType> AuditTypes { get; set; }
    public DbSet<Config> Configs { get; set; }
    public DbSet<Error> Errors { get; set; }
    public DbSet<UserFile> UserFiles { get; set; }
    public DbSet<Vessel> Vessels { get; set; }
    public DbSet<VesselFile> VesselFiles { get; set; }
    public DbSet<MailQueue> MailQueues { get; set; }

    public override int SaveChanges()
    {
        AddModificationDateAndTenant();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        AddModificationDateAndTenant();
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply configurations
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        // Configure decimal precision
        foreach (var property in modelBuilder.Model.GetEntityTypes()
                     .SelectMany(t => t.GetProperties())
                     .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
        {
            property.SetColumnType("decimal(18,2)");
        }

        // Global filters for soft delete & tenant
        if (_contextModificatorService?.IsGlobalQueryFiltersEnable == true)
        {
            modelBuilder.ApplyGlobalFilters<BaseEntity>(e =>
                !e.IsDeleted && (TenantName != null || e.TenantName == TenantName)
            );
        }

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        // Seed initial data
        modelBuilder.SeedData();

        modelBuilder.Entity<Tenant>(entity =>
        {
            entity.ToTable("Tenants");
            entity.HasKey(t => t.Id);
            entity.HasMany(t => t.Users)
                .WithOne(u => u.Tenant)
                .HasForeignKey(u => u.TenantId);
        });
        
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<Role>().ToTable("Roles");
        modelBuilder.Entity<IdentityUserRole<int>>().ToTable("UserRoles");
        modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
        modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");
        modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
        modelBuilder.Entity<IdentityUserToken<int>>().ToTable("UserTokens");
    }

    private void AddModificationDateAndTenant()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseEntity &&
                        (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            var entity = (BaseEntity)entityEntry.Entity;
            entity.ModifyDate = DateTime.UtcNow;

            if (TenantName != null)
                entity.TenantName = TenantName;

            if (entityEntry.State == EntityState.Added)
            {
                entity.CreatedDate = DateTime.UtcNow;
            }
        }
    }
}

// Extension for global filters
public static class ModelBuilderExtension
{
    public static void ApplyGlobalFilters<TInterface>(this ModelBuilder modelBuilder,
        Expression<Func<BaseEntity, bool>> expression)
    {
        var entities = modelBuilder.Model
            .GetEntityTypes()
            .Where(x => typeof(BaseEntity).IsAssignableFrom(x.ClrType))
            .Select(e => e.ClrType);

        foreach (var entity in entities)
        {
            var newParam = Expression.Parameter(entity);
            var newBody = ReplacingExpressionVisitor.Replace(expression.Parameters.Single(), newParam, expression.Body);
            modelBuilder.Entity(entity).HasQueryFilter(Expression.Lambda(newBody, newParam));
        }
    }
}
