using Microsoft.AspNetCore.Identity;

using backend.Extensions;
using backend.Interfaces;
using backend.Models;
using backend.Models.CartDto;

namespace backend.Services;

public class CartService : ICartService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ApiDbContext _context;
    private const string SessionKey = "CartSessionId";

    public CartService(UserManager<AppUser> userManager, ApiDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }
    public async Task<Cart> GetCartByUserId(string userId)
    {
        var cart = await _context.Carts
                            .Include(c => c.Items)
                            .ThenInclude(ci => ci.Product)
                            .FirstOrDefaultAsync(c => c.UserId == userId);

        if (cart == null) cart = await CreateCart(userId);
        return cart;
    }

    public async Task<Cart> CreateCart(string? userId = null)
    {
        var cart = new Cart
        {
            UserId = userId,
        };
        _context.Carts.Add(cart);
        await _context.SaveChangesAsync();

        return cart;
    }

    public async Task ClearCart(string userId)
    {
        var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
        if (cart == null) cart = await CreateCart(userId);
        cart.Items.Clear();
        await _context.SaveChangesAsync();
    }

    public async Task AddItemToCart(string userId, Guid productUuid, int quantity)
    {
        var cart = await _context.Carts.Include(c => c.Items).FirstOrDefaultAsync(c => c.UserId == userId);
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Uuid == productUuid);

        if (cart == null)
        {
            throw new InvalidOperationException($"Cart not found");
        }
        if (product == null)
        {
            throw new InvalidOperationException($"Product not found");
        }

        var cartItem = cart.Items.FirstOrDefault(ci => ci.ProductId == product.Id);

        if (cartItem == null)
        {
            var newCartItem = new CartItem
            {
                Quantity = quantity,
                ProductId = product.Id,
                Product = product,
                CartId = cart.Id,
                Cart = cart
            };
            cart.Items.Add(newCartItem);
        }
        else
        {
            cartItem.Quantity += quantity;
        }

        await _context.SaveChangesAsync();
    }

    public async Task SubtractItemFromCart(string userId, Guid productUuid, int quantity)
    {
        var cart = await _context.Carts.Include(c => c.Items).FirstOrDefaultAsync(c => c.UserId == userId);
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Uuid == productUuid);

        if (cart == null)
        {
            throw new InvalidOperationException($"Cart not found");
        }
        if (product == null)
        {
            throw new InvalidOperationException($"Product not found");
        }

        var cartItem = cart.Items.FirstOrDefault(ci => ci.ProductId == product.Id);

        if (cartItem == null)
        {
            throw new InvalidOperationException($"Cart Item not found");
        }

        if (cartItem.Quantity - quantity <= 0)
        {
            cart.Items.Remove(cartItem);
        }
        else
        {
            cartItem.Quantity -= quantity;
        }

        await _context.SaveChangesAsync();
    }

    public CartDisplayDto CartToCartDisplayDto(Cart cart)
    {
        return new CartDisplayDto
        {
            Items = cart.Items.Select(CartItemToCartItemDisplayDto).ToList()
        };
    }

    public CartItemDisplayDto CartItemToCartItemDisplayDto(CartItem cartItem)
    {
        return new CartItemDisplayDto
        {
            Quantity = cartItem.Quantity,
            Product = new CartProductDto
            {
                Uuid = cartItem.Product.Uuid,
                Name = cartItem.Product.Name,
                Price = cartItem.Product.Price,
                DiscountPrice = cartItem.Product.DiscountPrice,
            }
        };
    }
}