using backend.Interfaces;
using backend.Helpers;
using backend.Services;
using backend.Models;
using backend.Models.ProductDto;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly IProductService _productService;

        public ProductsController(ApiDbContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<PaginatedItem<ProductDetailDto>>> GetProducts([FromQuery] ProductQueryObject query)
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
                                .OrderBy(p => p.Id)
                                .Skip(pageNumber * pageSize)
                                .Take(pageSize)
                                .Select(p => _productService.ProductToProductDetailDto(p))
                                .ToListAsync();

            return Ok(new PaginatedItem<ProductDetailDto>(pageNumber, pageSize, totalItems, products));
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
        public async Task<IActionResult> PutProduct(long id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

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

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(long id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
