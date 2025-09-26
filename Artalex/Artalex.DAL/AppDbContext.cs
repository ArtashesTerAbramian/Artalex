using Artalex.DAL.Models;
using Artalex.DAL.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Artalex.BLL.Services.TenantService;

namespace Artalex.DAL;

public class AppDbContext : DbContext
{
    private readonly IContextModificatorService _contextModificatorService;
    private readonly ITenantService _tenantService;

    public AppDbContext(
        DbContextOptions options, 
        IContextModificatorService contextModificatorService,
        ITenantService tenantService) : base(options)
    {
        _contextModificatorService = contextModificatorService;
        _tenantService = tenantService;
    }

    public DbSet<Error> Errors { get; set; }

    public override int SaveChanges()
    {
        // AddModificationDate();
        AddModificationDateAndTenant();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // AddModificationDate();
        AddModificationDateAndTenant();
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);


        foreach (var property in modelBuilder.Model.GetEntityTypes()
                     .SelectMany(t => t.GetProperties())
                     .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
        {
            property.SetColumnType("decimal(18,2)");
        }
        
        if (_contextModificatorService?.IsGlobalQueryFiltersEnable == true)
        {
            var tenantId = _tenantService?.GetTenantId();
            modelBuilder.ApplyGlobalFilters<BaseEntity>(e =>
                !e.IsDeleted && (tenantId == null || e.TenantId == tenantId)
            );
        }

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        modelBuilder.SeedData();
    }

    private void AddModificationDate()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseEntity && (
                e.State == EntityState.Added
                || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            ((BaseEntity)entityEntry.Entity).ModifyDate = DateTime.UtcNow;

            if (entityEntry.State == EntityState.Added)
            {
                ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.UtcNow;
            }
        }
    }
    
    private void AddModificationDateAndTenant()
    {
        var tenantId = _tenantService?.GetTenantId();
        
        if (tenantId == null) return;

        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseEntity && (
                e.State == EntityState.Added
                || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            var entity = (BaseEntity)entityEntry.Entity;
            entity.ModifyDate = DateTime.UtcNow;
            entity.TenantId = tenantId;

            if (entityEntry.State == EntityState.Added)
            {
                entity.CreatedDate = DateTime.UtcNow;
            }
        }
    }
}

public static class ModelBuilderExtension
{
    public static void ApplyGlobalFilters<TInterface>(this ModelBuilder modelBuilder,
        Expression<Func<BaseEntity, bool>> expression)
    {
        var entities = modelBuilder.Model
            .GetEntityTypes()
            // .Where(x => x.ClrType.BaseType == typeof(BaseEntity))
            .Where(x => typeof(BaseEntity).IsAssignableFrom(x.ClrType))
            .Select(e => e.ClrType);
        foreach (var entity in entities)
        {
            var newParam = Expression.Parameter(entity);
            var newbody = ReplacingExpressionVisitor.Replace(expression.Parameters.Single(), newParam, expression.Body);
            modelBuilder.Entity(entity).HasQueryFilter(Expression.Lambda(newbody, newParam));
        }
    }
}