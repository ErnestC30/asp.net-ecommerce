using backend.Exceptions;
using backend.Helpers;
using backend.Interfaces;
using backend.Models;
using backend.Models.AccountDto;
using backend.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NSubstitute;


namespace backend.AddressServiceTests.Tests;

public class AddressServiceTests
{
    private readonly ApiDbContext _context; 
    private readonly UserManager<AppUser> _userManager;
    private readonly IAddressService _addressService;
    private static string _validUserId = "someUserId";
    private static string _existingAddressGuid = "3e9dcbb2-7e65-4c43-b804-5fb1b21c7ec0";

    public AddressServiceTests()
    {
        _context = GetDbContext();
        _userManager = CreateUserManager();
        _addressService = new AddressService(_context, _userManager);
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


        dbContext.UserAddresses.Add(new UserAddress 
        {  
            Uuid = Guid.Parse(_existingAddressGuid),
            UserId = _validUserId,
            Line1 = "line 1",
            Line2 = "line 2",
            Country = "country",
            City = "city",
            PostalCode = "1A2 B3C",
            IsPrimary = true,
        });

        dbContext.UserAddresses.Add(new UserAddress 
        {  
            Uuid = Guid.Parse("3e9dcbb2-7e65-4c43-b804-5fb1b21c7ec1"),
            UserId = _validUserId,
            Line1 = "line 1",
            Line2 = "line 2",
            Country = "country",
            City = "city",
            PostalCode = "1A2 B3C",
            IsPrimary = false,
        });

        dbContext.SaveChanges();

        return dbContext;
    }

    // Need this method since NSubstitute cannot substitute userManager directly
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
    public async Task GetAppUser_ShouldReturnAppUser_IfValidUserId()
    {
        // Arrange
        var userId = _validUserId;
        var user = _userManager.FindByIdAsync(Arg.Any<string>())
                       .Returns(Task.FromResult<AppUser?>(new AppUser { Id = userId }));

        // Act
        var appUser = await _addressService.GetAppUser(userId);

        // Assert
        Assert.NotNull(appUser);
    }

    [Fact]
    public async Task GetAppUser_ShouldRaiseException_IfInvalidUserId()
    {
        // Arrange
        var userId = "invalidId";
        var user = _userManager.FindByIdAsync(Arg.Any<string>())
                       .Returns(Task.FromResult<AppUser?>(null));

        // Act + Assert
        await Assert.ThrowsAsync<Exception>(() => _addressService.GetAppUser(userId));
    }

    [Fact]
    public async Task GetUserAddresses_ShouldReturnAddressesDto_WhenValidUserId()
    {
        // Arrange 
        var user = new AppUser { Id = _validUserId };

        // Act
        var addresses = await _addressService.GetUserAddresses(user);

        // Assert
        Assert.Equal(2, addresses.Count);
    }

    [Fact]
    public async Task GetUserAddresses_ShouldReturnEmptyAddressList_WhenNoAddressAdded()
    {
        // Arrange 
        var user = new AppUser { Id = "invalidId" };

        // Act
        var addresses = await _addressService.GetUserAddresses(user);

        // Assert
        Assert.Empty(addresses);
    }

    [Fact]
    public async Task CreateUserAddress_ShouldCreateAddress_WhenValidAddressData()
    {
        // Arrange
        var user = new AppUser { Id = _validUserId };
        var createDto = new UserAddressCreateDto
        {
            Line1 = "line 1",
            Line2 = "line 2",
            Country = "country",
            City = "city",
            PostalCode = "1A2 B3C",
            IsPrimary = false,
        };

        // Act
        var address = await _addressService.CreateUserAddress(createDto, user);

        // Assert
        Assert.NotNull(address);
        Assert.Equal("line 1", address.Line1);
    }

    [Fact]
    public async Task EditUserAddress_ShouldModifyAddress_WhenValidAddressData()
    {
        // Arrange
        var user = new AppUser { Id = _validUserId };
        var addressGuid = _existingAddressGuid;
        var editDto = new UserAddressEditDto
        {
            Line1 = "edited line 1",
            Line2 = "line 2",
            Country = "country",
            City = "city",
            PostalCode = "1A2 B3C",
            IsPrimary = false,
        };

        // Act 
        var address = await _addressService.EditUserAddress(editDto, addressGuid, user);

        // Assert
        Assert.Equal("edited line 1", address.Line1);
    }

    [Fact]
    public async Task EditUserAddress_ShouldThrowException_WhenInvalidAddressGuid()
    {
        // Arrange
        var user = new AppUser { Id = _validUserId };
        var invalidAddressGuid = "3e9dcbb2-7e65-4c43-b804-5fb1b21cabcd";
        var editDto = new UserAddressEditDto
        {
            Line1 = "edited line 1",
            Line2 = "line 2",
            Country = "country",
            City = "city",
            PostalCode = "1A2 B3C",
            IsPrimary = false,
        };

        // Act + Assert
        await Assert.ThrowsAsync<Exception>(() => _addressService.EditUserAddress(editDto, invalidAddressGuid, user));
    }

    [Fact]
    public async Task EditUserAddress_ShouldThrowException_WhenAddressUserIdDoesNotMatchUser()
    {        
        // Arrange
        var invalidUser = new AppUser { Id = "3e9dcbb2-7e65-4c43-b804-5fb1b21cabcd" };
        var addressId = _existingAddressGuid;
        var editDto = new UserAddressEditDto
        {
            Line1 = "edited line 1",
            Line2 = "line 2",
            Country = "country",
            City = "city",
            PostalCode = "1A2 B3C",
            IsPrimary = false,
        };

        // Act + Assert
        await Assert.ThrowsAsync<Exception>(() => _addressService.EditUserAddress(editDto, addressId, invalidUser));
    }

    [Fact]
    public async Task DeleteUserAddress_ShouldDeleteAddress_WhenValidAddressGuid()
    {
        // Arrange
        var addressId = _existingAddressGuid;

        // Act
        var deleted = await _addressService.DeleteUserAddress(addressId);
        var address = await _context.UserAddresses.FirstOrDefaultAsync(ua => ua.Uuid == Guid.Parse(addressId));

        // Assert
        Assert.True(deleted);
        Assert.Null(address);
    }

    [Fact]
    public async Task DeleteUserAddress_ShouldReturnFalse_WhenInvalidAddressGuid()
    {
        // Arrange
        var invalidAddressId = "3e9dcbb2-7e65-4c43-b804-5fb1b21c7abc";

        // Act
        var deleted = await _addressService.DeleteUserAddress(invalidAddressId);

        // Assert
        Assert.False(deleted);
    }
}
