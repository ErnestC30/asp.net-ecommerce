using System;

using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using backend.Models.CategoryDto;
using backend.Models.OrderDto;
using backend.Models.ProductDto;
using backend.Setup;
using backend.Helpers;

namespace backend.Models
{

    public class ApiDbContext : IdentityDbContext<AppUser>
    {
        private readonly IConfiguration _config;
        public ApiDbContext(DbContextOptions<ApiDbContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLineItem> OrderLineItems { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithOne(e => e.Category)
                .HasForeignKey(e => e.CategoryId)
                .HasPrincipalKey(e => e.Id);

            builder.Entity<Product>()
                .HasMany(e => e.ProductImages)
                .WithOne(e => e.Product)
                .HasForeignKey(e => e.ProductId)
                .HasPrincipalKey(e => e.Id);

            builder.Entity<RefreshToken>()
                .HasOne(e => e.User)
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(e => e.UserId);

            builder.Entity<Cart>()
                .HasMany(e => e.Items)
                .WithOne(e => e.Cart)
                .HasForeignKey(e => e.CartId)
                .HasPrincipalKey(e => e.Id);

            builder.Entity<Cart>()
                .HasOne(c => c.AppUser)
                .WithOne(u => u.Cart)
                .HasForeignKey<Cart>(c => c.UserId)
                .IsRequired(false);

            builder.Entity<CartItem>()
                .HasOne(e => e.Product)
                .WithMany()
                .HasForeignKey(e => e.ProductId);

            builder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            builder.Entity<Order>()
                .HasMany(o => o.LineItems)
                .WithOne(li => li.Order)
                .HasForeignKey(li => li.OrderId)
                .HasPrincipalKey(o => o.Id);

            builder.Entity<Order>()
                .HasOne(o => o.OrderStatus)
                .WithMany(os => os.Orders)
                .HasForeignKey(o => o.OrderStatusId);

            List<IdentityRole> roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Id = "68b87a0e-9047-4e42-975d-98943d0cd843",
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = "75971a93-05e1-410c-b3e8-5baa976403e5",
                Name = "User",
                NormalizedName = "USER"
            },
        };
            builder.Entity<IdentityRole>().HasData(roles);

            if (_config.GetValue<bool>("SetupData:UseSeeding"))
            {
                SeedCategoryAndProducts(builder);
                SeedOrderStatuses(builder);
            }
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

        private void SeedCategoryAndProducts(ModelBuilder builder)
        {
            var setupBasePath = _config["SetupData:BasePath"] ?? "";

            string categoriesJson = File.ReadAllText(Path.Combine(setupBasePath, "categories.json"));
            List<CreateCategoryDto> categoryDtos = JsonConvert.DeserializeObject<List<CreateCategoryDto>>(categoriesJson) ?? new List<CreateCategoryDto>(); ;
            var categories = categoryDtos.Select((c, idx) => new Category
            {
                Id = idx + 1,
                Slug = SlugHelper.GenerateSlug(c.Name),
                Name = c.Name,
                Description = c.Description
            });
            builder.Entity<Category>().HasData(categories);


            string productsJson = File.ReadAllText(Path.Combine(setupBasePath, "products.json"));
            List<SetupProduct> productDtos = JsonConvert.DeserializeObject<List<SetupProduct>>(productsJson) ?? new List<SetupProduct>();

            var products = productDtos.Select((p, idx) => new Product
            {
                Id = idx + 1,
                Uuid = p.Uuid,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                DiscountPrice = p.DiscountPrice,
                Quantity = p.Quantity,
                IsActive = p.IsActive,
                CategoryId = p.CategoryId
            });
            builder.Entity<Product>().HasData(products);

        }

        private void SeedOrderStatuses(ModelBuilder builder)
        {
            var setupBasePath = _config["SetupData:BasePath"] ?? "";

            string orderStatusesJson = File.ReadAllText(Path.Combine(setupBasePath, "order_statuses.json"));
            List<OrderStatusCreateDto> orderStatusDtos = JsonConvert.DeserializeObject<List<OrderStatusCreateDto>>(orderStatusesJson) ?? new List<OrderStatusCreateDto>(); ;

            var orderStatuses = orderStatusDtos.Select((os, idx) => new OrderStatus
            {
                Id = idx + 1,
                Name = os.Name,
                Slug = os.Slug ?? SlugHelper.GenerateSlug(os.Name)
            });
            builder.Entity<OrderStatus>().HasData(orderStatuses);
        }
    }
}