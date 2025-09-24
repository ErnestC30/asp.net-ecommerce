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

    private ApiDbContext _context;
    private ICategoryService _categoryService;
    private IProductService _productService;
    private static long _exampleId = 1;

    public ProductServiceTests()
    {
        _context = GetDbContext();
        _categoryService = Substitute.For<ICategoryService>();
        _productService = new ProductService(_context, _categoryService);
    }

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
            Id = _exampleId,
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
    public async Task GetProductById_ShouldReturnProduct_WhenValidId()
    {
        // Arrange
        long id = _exampleId;

        // Act
        var product = await _productService.GetProductById(id);

        // Assert
        Assert.Equal(_exampleId, product?.Id);
    }

    [Fact]
    public async Task GetProductById_ShouldReturnNull_WhenInvalidId()
    {
        // Arrange
        long id = 5;

        // Act
        var product = await _productService.GetProductById(id);

        // Assert
        Assert.Null(product);
    }

    [Fact]
    public async Task CreateProduct_ShouldCreateNewProduct()
    {
        // Arrange
        var dto = new CreateProductDto
        {
            Name = "Product",
            Price = 10.00M,
            Quantity = 1,
            IsActive = true,
            CategoryId = 1
        };

        // Act
        var product = await _productService.CreateProduct(dto);

        // Assert
        Assert.Equal("Product", product.Name);

    }

    [Fact]
    public async Task ModifyProduct_ShouldReplaceExistingProduct_WhenValidIdAndDto()
    {
        // Arrange 
        long id = _exampleId;
        var modifiedProduct = new ProductModificationDto
        {
            Name = "Updated Product",
            Price = 15.00M,
            Quantity = 2,
            IsActive = true,
            CategoryId = 1
        };

        // Act
        bool success = await _productService.ModifyProduct(_exampleId, modifiedProduct);
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == _exampleId);

        // Assert
        Assert.True(success);
        Assert.Equal("Updated Product", product?.Name);
    }

    [Fact]
    public async Task ModifyProduct_ShouldReturnFalse_WhenInvalidId()
    {
        // Arrange
        long invalidId = 10;
        var modifiedProduct = new ProductModificationDto
        {
            Name = "Updated Product",
            Price = 15.00M,
            Quantity = 2,
            IsActive = true,
            CategoryId = 1
        };

        // Act
        bool success = await _productService.ModifyProduct(invalidId, modifiedProduct);

        // Assert
        Assert.False(success);
    }

    [Fact]
    public async Task DeleteProduct_ShouldDeleteProduct_WhenGivenValidId()
    {
        // Arrange

        // Act
        bool success = await _productService.DeleteProduct(_exampleId);
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == _exampleId);

        // Assert
        Assert.True(success);
        Assert.Null(product);
    }

    [Fact]
    public async Task DeleteProduct_ShouldReturnFalse_WhenGivenInvalidId()
    {
        // Arrange
        long invalidId = 10;

        // Act
        bool success = await _productService.DeleteProduct(invalidId);

        // Assert
        Assert.False(success);
    }


    [Fact]
    public void ProductToProductDetailDto_ShouldConvertProductModelToProductDetailDto()
    {
        // Arrange
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

        // Act
        _categoryService.CategoryToCategoryInfoDto(product.Category).Returns(new CategoryInfoDto
        {
            Name = "Category",
            Slug = "category",
            Description = "description"
        });
        var dto = _productService.ProductToProductDetailDto(product);

        // Assert
        Assert.NotNull(dto.Category);
        Assert.Equal("Sample Product", dto.Name);
        Assert.True(dto.IsActive);
        Assert.Equal("Category", dto.Category.Name);
    }
}