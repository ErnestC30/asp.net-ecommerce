using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using backend.Helpers;
using backend.Models;
using backend.Models.ProductDto;

namespace backend.Interfaces;

public interface IProductService
{
    public Task<Product?> GetProductById(long id);
    public Task<PaginatedItem<ProductDetailDto>> GetFilteredProducts(ProductQueryObject query);
    public Task<Product> CreateProduct(CreateProductDto createProductDto);
    public Task<bool> ModifyProduct(long id, ProductModificationDto modifyProductDto);
    public Task AddProductImage(long productId, IFormFile file, int order);
    public Task RemoveProductImage(long productImageId);
    public Task<bool> DeleteProduct(long id);
    public ProductDetailDto ProductToProductDetailDto(Product product);
}
