using backend.Exceptions;
using backend.Helpers;
using backend.Interfaces;
using backend.Models;
using backend.Models.CategoryDto;
using backend.Models.ProductDto;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Text;

// Need to update namespace from default to prevent namespace clash
namespace backend.ProductServiceTests.UnitTests;

/*
 Need to be careful testing the methods using 'ProductToProductDetailDto' since it relies on functioning ICategoryService
 => requires mocking the return for CategoryService to get the correct Category data
 */


public class ProductServiceTests
{

    private ApiDbContext _context;
    private ICategoryService _categoryService;
    private IProductImageService _productImageService;
    private ILogger<ProductService> _logger;
    private IProductService _productService;
    private static long _exampleId = 1;

    public ProductServiceTests()
    {
        _context = GetDbContext();
        _categoryService = Substitute.For<ICategoryService>();
        _productImageService = Substitute.For<IProductImageService>();
        _logger = Substitute.For<ILogger<ProductService>>();
        _productService = new ProductService(_context, _categoryService, _productImageService, _logger);
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

        dbContext.Categories.Add(new Category { Id = 1, Name = "Category 1", Slug = "category" });
        dbContext.Categories.Add(new Category { Id = 2, Name = "Category 2", Slug = "category_2" });

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
        dbContext.Products.Add(new Product
        {
            Id = _exampleId + 1,
            Uuid = new Guid("3c3a7883-3a13-4226-a0de-61222f1093ad"),
            Name = "Sample Product 2",
            Price = 20.00M,
            Quantity = 2,
            IsActive = true,
            CategoryId = 2
        });

        dbContext.SaveChanges();

        return dbContext;
    }

    private IFormFile CreateFormFile(string fileName, string contentType)
    {
        var content = "Some content";
        var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

        return new FormFile(stream, 0, stream.Length, "file", fileName)
        {
            Headers = new HeaderDictionary(),
            ContentType = contentType
        };
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
    public async Task GetFilteredProducts_ShouldReturnCategory1_WhenFilteringCategory1()
    {
        // Arrange
        var query = new ProductQueryObject
        {
            CategoryId = 1
        };

        // Act
        var paginatedProducts = await _productService.GetFilteredProducts(query);
        _categoryService.CategoryToCategoryInfoDto(Arg.Any<Category>()).Returns(new CategoryInfoDto
        {
            Name = "Category 1",
            Slug = "category",
            Description = "description"
        });

        // Assert
        Assert.Equal(1, paginatedProducts.TotalCount);
        foreach (var product in paginatedProducts.Data)
        {
            Assert.NotNull(product.Category);
            Assert.Equal("Category 1", product.Category.Name);
        }
    }

    [Fact]
    public async Task GetFilteredProducts_ShouldReturnPaginatedProducts_WhenUsingPageNumAndSize()
    {
        // Arrange
        var query = new ProductQueryObject
        {
            PageNumber = 1,
            PageSize = 1
        };

        // Act
        var paginatedProducts = await _productService.GetFilteredProducts(query);

        // Assert
        Assert.Equal(2, paginatedProducts.TotalCount);
        Assert.Single(paginatedProducts.Data);
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
    public async Task AddProductImage_ShouldCreateNewProductImage_WhenValidFormFileAdded()
    {
        // Arrange
        var productId = _exampleId;
        var imageFile = CreateFormFile("ImageFile.png", "image/png");
        int order = 0;

        // Act
        _productImageService.UploadImage(imageFile).Returns("file path");
        await _productService.AddProductImage(productId, imageFile, order);
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == _exampleId);

        // Assert
        Assert.NotNull(product);
        Assert.NotNull(product.Images);
        Assert.Single(product.Images);
    }

    [Fact]
    public async Task AddProductImage_ShouldRaiseUnsupportedFileTypeExtension_WhenInvalidFileType()
    {
        // Arrange
        var productId = _exampleId;
        var imageFile = CreateFormFile("ImageFile.gif", "image/gif");
        int order = 0;

        // Act + Assert
        await Assert.ThrowsAsync<UnsupportedFileTypeException>(() => _productService.AddProductImage(productId, imageFile, order));
    }

    [Fact]
    public async Task AddProductImage_ShouldRaiseKeyNotFoundException_WhenInvalidProductId()
    {
        // Arrange
        var productId = 100;
        var imageFile = CreateFormFile("ImageFile.png", "image/png");
        int order = 0;

        // Act + Assert
        await Assert.ThrowsAsync<KeyNotFoundException>(() => _productService.AddProductImage(productId, imageFile, order));
    }

    [Fact]
    public async Task RemoveProductImage_ShouldRemoveProductImage_WhenValidImageId()
    {
        // Arrange 
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == _exampleId);
        product!.Images.Add(new ProductImage
        {
            Url = "File link",
            ProductId = _exampleId,
            Product = product
        });
        await _context.SaveChangesAsync();
        var imageId = product.Images.First().Id;

        // Act 
        await _productService.RemoveProductImage(imageId);

        // Assert
        Assert.Empty(product.Images);
    }

    [Fact]
    public async Task RemoveProductImage_ShouldRaiseException_WhenInvalidProductImageId()
    {
        // Arrange 
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == _exampleId);
        product!.Images.Add(new ProductImage
        {
            Url = "File link",
            ProductId = _exampleId,
            Product = product
        });
        await _context.SaveChangesAsync();
        var imageId = product.Images.First().Id;

        // Act + Assert
        await Assert.ThrowsAsync<KeyNotFoundException>(() => _productService.RemoveProductImage(100));
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