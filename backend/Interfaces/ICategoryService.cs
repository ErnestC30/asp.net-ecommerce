using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using backend.Models;
using backend.Models.CategoryDto;

namespace backend.Interfaces;

public interface ICategoryService
{
    public CategoryInfoDto CategoryToCategoryInfoDto(Category category);
    public CategoryDetailDto CategoryToCategoryDetailDto(Category category);
}
