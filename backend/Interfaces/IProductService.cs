using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using backend.Models;
using backend.Models.ProductDto;

namespace backend.Interfaces;

public interface IProductService
{
    Task<Product> CreateProduct(CreateProductDto createProductDto);
    ProductDetailDto ProductToProductDetailDto(Product product);
}
