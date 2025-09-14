using System;

using backend.Interfaces;
using backend.Models;
using backend.Models.ProductDto;
using backend.Models.CategoryDto;
using backend.Helpers;
using backend.Services;

namespace backend.Services;

public class ProductService : IProductService
{
    private readonly ApiDbContext _context;

    private readonly ICategoryService _categoryService;

    public ProductService(ApiDbContext apiDbContext, ICategoryService categoryService)
    {
        _context = apiDbContext;
        _categoryService = categoryService;
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

    public ProductDetailDto ProductToProductDetailDto(Product product)
    {
        CategoryInfoDto? categoryDto = null;
        if (product.Category != null)
        {
            categoryDto = _categoryService.CategoryToCategoryInfoDto(product.Category);
        }

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
            Category = categoryDto
        };
    }

}