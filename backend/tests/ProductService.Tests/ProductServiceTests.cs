using Xunit;
using NSubstitute;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using backend.Interfaces;
using backend.Models;
using backend.Models.ProductDto;
using backend.Models.CategoryDto;
using backend.Services;

namespace backend.ProductServiceTests.UnitTests;

public class ProductServiceTests
{
    public static ApiDbContext GetDbContext(bool useSeeding = false)
    {
        var options = new DbContextOptionsBuilder<ApiDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
        var inMemorySettings = new Dictionary<string, string?>
        {
            {"SetupData:UseSeeding", useSeeding.ToString()}
        };
        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();
        var dbContext = new ApiDbContext(options, config);

        dbContext.Categories.Add(new Category { Id = 1, Name = "Category", Slug = "category" });
        dbContext.Products.Add(new Product
        {
            Id = 1,
            Uuid = new Guid("3c3a7883-3a13-4226-a0de-61222f1093ae"),
            Name = "Sample Product",
            Price = 10.00M,
            Quantity = 2,
            IsActive = true,
            CategoryId = 1
        });
        dbContext.SaveChanges();

        return dbContext;
    }

    [Fact]
    public async Task CreateProduct_ShouldCreateProductWithCategory()
    {
        var context = GetDbContext();
        var mockCategoryService = Substitute.For<ICategoryService>();
        var productService = new ProductService(context, mockCategoryService);

        var dto = new CreateProductDto
        {
            Name = "Product",
            Price = 10.00M,
            Quantity = 1,
            IsActive = true,
            CategoryId = 1
        };

        var product = await productService.CreateProduct(dto);

        Assert.Equal("Product", product.Name);

    }

    [Fact]
    public void ProductService_ShouldConvertProductToProductDetailDto()
    {
        var context = GetDbContext();
        var category = new Category { Id = 1, Name = "Category", Slug = "category" };
        var product = new Product
        {
            Id = 1,
            Uuid = new Guid("3c3a7883-3a13-4226-a0de-61222f1093ae"),
            Name = "Sample Product",
            Price = 10.00M,
            Quantity = 2,
            IsActive = true,
            CategoryId = 1,
            Category = category
        };
        var mockCategoryService = Substitute.For<ICategoryService>();
        mockCategoryService.CategoryToCategoryInfoDto(product.Category).Returns(new CategoryInfoDto
        {
            Name = "Category",
            Slug = "category",
            Description = "description"
        });

        var productService = new ProductService(context, mockCategoryService);
        var dto = productService.ProductToProductDetailDto(product);

        Assert.NotNull(dto.Category);
        Assert.Equal("Sample Product", dto.Name);
        Assert.True(dto.IsActive);
        Assert.Equal("Category", dto.Category.Name);
    }
}