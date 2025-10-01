using backend.Exceptions;
using backend.Helpers;
using backend.Interfaces;
using backend.Models;
using backend.Models.CategoryDto;
using backend.Models.ProductDto;
using backend.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NSubstitute;


namespace backend.CartServiceTests.Tests;

public class CartServiceTests
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ApiDbContext _context;
    private readonly ICartService _cartService;

    private static int _cartId = 1;
    private static int _exampleId = 1;
    private static string _userId = "3c3a7883-3a13-4226-a0de-61222f1093ae";
    private static string _product1Uuid = "f30e7b92-6d16-4584-9b75-08299ce8f280";
    private static string _product2Uuid = "621422ec-6ab7-4785-bd21-c8d5bb07c216";

    public CartServiceTests()
    {
        _context = GetDbContext();
        _userManager = CreateUserManager();
        _cartService = new CartService(_userManager, _context);
    }

    public static ApiDbContext GetDbContext(bool useSeeding = false)
    {
        var options = new DbContextOptionsBuilder<ApiDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
        var inMemorySettings = new Dictionary<string, string?>
        {
            {"SetupData:UseSeeding", useSeeding.ToString()}
        };
        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();
        var dbContext = new ApiDbContext(options, config);

        dbContext.Categories.Add(new Category { Id = 1, Name = "Category 1", Slug = "category" });
        dbContext.Categories.Add(new Category { Id = 2, Name = "Category 2", Slug = "category_2" });

        var product1 = new Product
        {
            Id = _exampleId,
            Uuid = new Guid(_product1Uuid),
            Name = "Sample Product",
            Price = 10.00M,
            Quantity = 2,
            IsActive = true,
            CategoryId = 1

        };

        dbContext.Products.Add(product1);
        dbContext.Products.Add(new Product
        {
            Id = _exampleId + 1,
            Uuid = new Guid(_product2Uuid),
            Name = "Sample Product 2",
            Price = 20.00M,
            Quantity = 2,
            IsActive = true,
            CategoryId = 2
        });

        var cart = new Cart
        {
            Id = _cartId,
            AppUser = new AppUser { Id = _userId }
        };

        cart.Items.Add(new CartItem { Id = 1, Quantity = 2, ProductId = _exampleId, Product = product1, CartId = _cartId, Cart = cart });

        dbContext.Carts.Add(cart);

        dbContext.SaveChanges();

        return dbContext;
    }

    private static UserManager<AppUser> CreateUserManager()
    {
        var store = Substitute.For<IUserStore<AppUser>>();

        return new UserManager<AppUser>(
            store,
            null!,
            null!,
            new IUserValidator<AppUser>[0],
            new IPasswordValidator<AppUser>[0],
            null!,
            null!,
            null!,
            null!
        );
    }

    [Fact]
    public async Task GetCartByUserId_ShouldReturnCart_WhenValidUserIdWithExistingCart()
    {
        // Arrange
        var userId = _userId;

        // Act
        var cart = await _cartService.GetCartByUserId(userId);

        // Assert
        Assert.NotNull(cart);
        Assert.Equal(_userId, cart.AppUser!.Id);
    }

    [Fact]
    public async Task GetCartByUserId_ShouldCreateNewCart_WhenValidUserWithNoCart()
    {
        // Arrange
        var userId = "3c3a7883-3a13-4226-a0de-61222f109abc";

        // Act
        var cart = await _cartService.GetCartByUserId(userId);

        // Assert
        Assert.NotNull(cart);
        Assert.Equal(userId, cart.UserId);
    }

    [Fact]
    public async Task ClearCart_ShouldRemoveCartItemsFromCart_WhenValidUserId()
    {
        // Arrange 
        var userId = _userId;

        // Act
        await _cartService.ClearCart(userId);
        var cart = _context.Carts.Where(c => c.UserId == userId).FirstOrDefault();

        // Assert
        Assert.NotNull(cart);
        Assert.Empty(cart.Items);
    }

    [Fact]
    public async Task AddItemToCart_ShouldUpdateCartItemQuantity_WhenIncreasingQuantityOfCartItem()
    {
        // Arrange
        var userId = _userId;
        var productUuid = Guid.Parse(_product1Uuid);
        int quantity = 1;

        // Act
        await _cartService.AddItemToCart(userId, productUuid, quantity);
        var cart = await _cartService.GetCartByUserId(userId);
        var cartItem = cart.Items.First(ci => ci.Product.Uuid == productUuid);

        // Assert
        Assert.Equal(3, cartItem.Quantity);
    }

    [Fact]
    public async Task AddItemToCart_ShouldAddCartItem_WhenAddingNewItemToCart()
    {
        // Arrange
        var userId = _userId;
        var productUuid = Guid.Parse(_product2Uuid);
        int quantity = 1;

        // Act
        await _cartService.AddItemToCart(userId, productUuid, quantity);
        var cart = await _cartService.GetCartByUserId(userId);
        var cartItem = cart.Items.First(ci => ci.Product.Uuid == productUuid);

        // Assert
        Assert.Equal(2, cart.Items.Count);
        Assert.Equal(1, cartItem.Quantity);
    }

    [Fact]
    public async Task SubtractItemFromCart_ShouldDecreaseCartItemQuantity_WhenSubtractingExistingItem()
    {
        // Arrange
        var userId = _userId;
        var productUuid = Guid.Parse(_product1Uuid);
        int quantity = 1;

        // Act
        await _cartService.SubtractItemFromCart(userId, productUuid, quantity);
        var cart = await _cartService.GetCartByUserId(userId);
        var cartItem = cart.Items.First(ci => ci.Product.Uuid == productUuid);

        // Assert
        Assert.Equal(1, cartItem.Quantity);
    }

    [Fact]
    public async Task SubtractItemFromCart_ShouldRemoveItemFromCart_WhenQuantityIsZero()
    {
        // Arrange
        var userId = _userId;
        var productUuid = Guid.Parse(_product1Uuid);
        int quantity = 2;

        // Act
        await _cartService.SubtractItemFromCart(userId, productUuid, quantity);
        var cart = await _cartService.GetCartByUserId(userId);
        var cartItem = cart.Items.FirstOrDefault(ci => ci.Product.Uuid == productUuid);

        // Assert
        Assert.Empty(cart.Items);
        Assert.Null(cartItem);
    }

    [Fact]
    public async Task CartToCartDisplayDto_ShouldConvertCartToDto()
    {
        // Arrange
        var userId = _userId;
        var cart = await _cartService.GetCartByUserId(userId);

        // Act
        var dto = _cartService.CartToCartDisplayDto(cart);

        // Assert
        Assert.Equal(2, dto.Items[0].Quantity);
    }
}
