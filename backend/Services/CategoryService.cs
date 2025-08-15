using backend.Interfaces;
using backend.Models;
using backend.Models.CategoryDto;

namespace backend.Services;

public class CategoryService : ICategoryService
{
    public CategoryInfoDto CategoryToCategoryInfoDto(Category category)
    {
        return new CategoryInfoDto
        {
            Name = category.Name,
            Slug = category.Slug,
            Description = category.Description
        };
    }

    public CategoryDetailDto CategoryToCategoryDetailDto(Category category)
    {
        return new CategoryDetailDto
        {
            Id = category.Id,
            Name = category.Name,
            Slug = category.Slug,
            Description = category.Description,
            // Products = category.Products,
            CreatedAt = category.CreatedAt,
            UpdatedAt = category.UpdatedAt
        };
    }
}