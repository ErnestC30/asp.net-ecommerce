using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using backend.Models;
using backend.Models.ProductDto;

namespace backend.Interfaces;

public interface IProductService
{
    public Task<Product?> GetProductById(long id);
    public Task<Product> CreateProduct(CreateProductDto createProductDto);
    public ProductDetailDto ProductToProductDetailDto(Product product);
}
