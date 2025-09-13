using backend.Models;

namespace backend.Interfaces;

public interface ICartService
{
    public Task<Cart> GetCartByUserId(string userId);
    public Task<Cart> CreateCart(string? userId);
    public Task ClearCart(string userId);
    public Task AddItemToCart(string userId, Guid productUuid, int quantity);
    public Task SubtractItemFromCart(string userId, Guid productUuid, int quantity);

}