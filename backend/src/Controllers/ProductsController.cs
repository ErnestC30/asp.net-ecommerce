using backend.Interfaces;
using backend.Helpers;
using backend.Services;
using backend.Models;
using backend.Models.ProductDto;
using backend.Exceptions;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(ApiDbContext context, IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<PaginatedItem<ProductDetailDto>>> GetProducts([FromQuery] ProductQueryObject query)
        {
            var paginatedProducts = await _productService.GetFilteredProducts(query);
            return Ok(paginatedProducts);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetailDto>> GetProduct(long id)
        {
            var product = await _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            var productDto = _productService.ProductToProductDetailDto(product);
            return productDto;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutProduct(long id, [FromBody] ProductModificationDto modifyProductDto)
        {

            var success = await _productService.ModifyProduct(id, modifyProductDto);

            if (!success) return BadRequest();
            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Product>> PostProduct([FromBody] CreateProductDto createProductDto)
        {
            var product = await _productService.CreateProduct(createProductDto);

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        [HttpPost("{id}/images")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddProductImage(long id, [FromForm] ProductImageCreateDto productImageCreateDto)
        {

            if (!ModelState.IsValid) return BadRequest();

            try
            {
                await _productService.AddProductImage(id, productImageCreateDto.File, productImageCreateDto.Order);
            }
            catch (UnsupportedFileTypeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpDelete("images")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveProductImage(long productImageId)
        {
            try
            {
                await _productService.RemoveProductImage(productImageId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            var deleted = await _productService.DeleteProduct(id);

            if (!deleted) return BadRequest();

            return NoContent();
        }
    }
}
