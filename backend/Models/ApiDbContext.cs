namespace backend.Models;

using Microsoft.EntityFrameworkCore;

using Helpers;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
        .HasMany(e => e.Products)
        .WithOne(e => e.Category)
        .HasForeignKey(e => e.CategoryId)
        .HasPrincipalKey(e => e.Id);
    }

    public override int SaveChanges()
    {
        GenerateSlugs();
        UpdateTimestamps();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        GenerateSlugs();
        UpdateTimestamps();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateTimestamps()
    {
        var entries = ChangeTracker.Entries<BaseEntity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
            }
            if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }
        }
    }

    private void GenerateSlugs()
    {
        var newCategories = ChangeTracker.Entries<Category>().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        foreach (var entry in newCategories)
        {
            var category = entry.Entity;
            category.Slug = SlugHelper.GenerateSlug(category.Name);
        }

        var newProducts = ChangeTracker.Entries<Product>().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        foreach (var entry in newProducts)
        {
            var product = entry.Entity;
            product.Slug = SlugHelper.GenerateSlug(product.Name);
        }
    }
}