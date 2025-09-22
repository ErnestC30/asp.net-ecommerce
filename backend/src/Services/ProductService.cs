using backend.Exceptions;
using backend.Helpers;
using backend.Interfaces;
using backend.Models;
using backend.Models.CategoryDto;
using backend.Models.ProductDto;
using backend.Services;
using Microsoft.CodeAnalysis;
using System;

namespace backend.Services;

public class ProductService : IProductService
{
    private readonly ApiDbContext _context;
    private readonly ICategoryService _categoryService;
    private readonly IProductImageService _productImageService;
    private readonly ILogger<ProductService> _logger;


    public ProductService(ApiDbContext apiDbContext, ICategoryService categoryService, IProductImageService productImageService, ILogger<ProductService> logger)
    {
        _context = apiDbContext;
        _categoryService = categoryService;
        _productImageService = productImageService;
        _logger = logger;
    }

    public async Task<Product?> GetProductById(long id)
    {
        var product = await _context.Products.FindAsync(id);
        return product;
    }

    public async Task<PaginatedItem<ProductDetailDto>> GetFilteredProducts(ProductQueryObject query)
    {
        var pageNumber = query.PageNumber;
        var pageSize = query.PageSize;
        var categoryId = query.CategoryId;

        var productsQuery = (IQueryable<Product>)_context.Products.Include(p => p.Category);

        if (categoryId != null)
        {
            productsQuery = productsQuery.Where(p => p.CategoryId != null && p.CategoryId == categoryId);
        }

        var totalItems = await productsQuery.LongCountAsync();

        var products = await productsQuery
            .Include(p => p.ProductImages)
            .OrderBy(p => p.Id)
            .Skip(pageNumber * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var productsDto = products.Select(p => ProductToProductDetailDto(p));

        return new PaginatedItem<ProductDetailDto>(pageNumber, pageSize, totalItems, productsDto);
    }

    public async Task<Product> CreateProduct(CreateProductDto createProductDto)
    {
        var category = await _context.Categories.FindAsync(createProductDto.CategoryId);

        if (category == null)
        {
            throw new KeyNotFoundException($"Category with ID {createProductDto.CategoryId} was not found.");
        }

        var product = new Product
        {
            Uuid = Guid.NewGuid(),
            Name = createProductDto.Name,
            Description = createProductDto.Description,
            Price = createProductDto.Price,
            DiscountPrice = createProductDto.DiscountPrice,
            Quantity = createProductDto.Quantity,
            IsActive = createProductDto.IsActive,
            CategoryId = createProductDto.CategoryId,
            Category = category
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<bool> ModifyProduct(long id, ProductModificationDto modifyProductDto)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            return false;
        }

        product.Name = modifyProductDto.Name;
        product.Description = modifyProductDto.Description;
        product.Price = modifyProductDto.Price;
        product.DiscountPrice = modifyProductDto.DiscountPrice;
        product.IsActive = modifyProductDto.IsActive;
        product.CategoryId = modifyProductDto.CategoryId;

        _context.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task AddProductImage(long productId, IFormFile file, int order = 0)
    {
        // Add another method to handle multiple image files uploaded at once?

        if (!IsValidImageFileType(file)) { throw new UnsupportedFileTypeException("Images must be of the following types: .jpg, .jpeg, .png, .webp"); }

        var product = await _context.Products.Include(p => p.ProductImages).FirstOrDefaultAsync(p => p.Id == productId);

        if (product == null) { throw new KeyNotFoundException($"Product with ID: {productId} could not be found."); }

        var filename = Path.GetFileName(file.FileName);
        bool exists = product.ProductImages.Any(pi => pi.Url == filename);
        // Do not need to upload image again if file with filename already exists
        if (exists) { return; }

        var filePath = await _productImageService.UploadImage(file);
        product.ProductImages.Add(new ProductImage { Url = filename, Order = order, ProductId = productId, Product = product });
        await _context.SaveChangesAsync();
        _logger.LogInformation($"Image uploaded to {filePath}");
    }

    public async Task RemoveProductImage(long productImageId)
    {
        var productImage = await _context.ProductImages.FirstOrDefaultAsync(p => p.Id == productImageId);

        if (productImage == null) { throw new KeyNotFoundException($"Product Image with ID: {productImageId} could not be found."); }

        _context.ProductImages.Remove(productImage);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteProduct(long id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return false;
        }
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return true;
    }

    public ProductDetailDto ProductToProductDetailDto(Product product)
    {
        CategoryInfoDto? categoryDto = null;
        if (product.Category != null)
        {
            categoryDto = _categoryService.CategoryToCategoryInfoDto(product.Category);
        }

        List<ProductImageDto> images = product.ProductImages
            .Select(img => new ProductImageDto { Url = _productImageService.GetImagePath(img.Url), Order = img.Order })
            .ToList();

        return new ProductDetailDto
        {
            Id = product.Id,
            Uuid = product.Uuid,
            Name = product.Name,
            Slug = product.Slug ?? "",
            Description = product.Description,
            Price = product.Price,
            DiscountPrice = product.DiscountPrice,
            Quantity = product.Quantity,
            IsActive = product.IsActive,
            Category = categoryDto,
            Images = images
        };
    }

    private static bool IsValidImageFileType(IFormFile file)
    {
        HashSet<string> validFileTypes = new()
        {
            ".jpg", ".jpeg", ".png", ".webp"
        };

        HashSet<string> validContentTypes = new()
        {
            "image/jpeg",
            "image/png",
            "image/webp"
        };

        var fileType = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (string.IsNullOrEmpty(fileType) || !validFileTypes.Contains(fileType)) return false;
        if (!validContentTypes.Contains(file.ContentType)) return false;

        return true;

    }



}