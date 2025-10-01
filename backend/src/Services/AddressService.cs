using backend.Interfaces;
using backend.Models;
using backend.Models.AccountDto;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace backend.Services;

public class AddressService : IAddressService
{
    private readonly ApiDbContext _context;
    private readonly UserManager<AppUser> _userManager;

    public AddressService(ApiDbContext context, UserManager<AppUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<AppUser> GetAppUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) throw new Exception($"User with id {userId} not found.");
        return user;
    }

    public async Task<ICollection<UserAddressViewDto>> GetUserAddresses(AppUser user)
    {
        var addresses = await _context.UserAddresses.Where(ua => ua.UserId == user.Id).Select(ua => UserAddressToUserAddressViewDto(ua)).ToListAsync();
        return addresses;
    }

    public async Task<UserAddress> CreateUserAddress(UserAddressCreateDto createDto, AppUser user)
    {
        if (createDto.IsPrimary) await ResetPrimaryAddress(user);

        var address = new UserAddress
        {
            UserId = user.Id,
            Uuid = Guid.NewGuid(),
            Line1 = createDto.Line1,
            Line2 = createDto.Line2,
            Country = createDto.Country,
            City = createDto.City,
            PostalCode = createDto.PostalCode,
            IsPrimary = createDto.IsPrimary,
        };

        _context.UserAddresses.Add(address);
        await _context.SaveChangesAsync();

        return address;
    }

    public async Task<UserAddress> EditUserAddress(UserAddressEditDto editDto, string addressGuid, AppUser user)
    {
        var address = await _context.UserAddresses.FirstOrDefaultAsync(ua => ua.Uuid == Guid.Parse(addressGuid)) ?? throw new Exception($"Could not find matching user address.");
        if (address.UserId != user.Id) throw new Exception("Invalid user for editing address");

        if (editDto.IsPrimary) await ResetPrimaryAddress(user);

        address.Line1 = editDto.Line1;
        address.Line2 = editDto.Line2;  
        address.Country = editDto.Country;
        address.City = editDto.City;
        address.PostalCode = editDto.PostalCode;
        address.IsPrimary = editDto.IsPrimary;

        await _context.SaveChangesAsync();
        return address;
    }

    public async Task<bool> DeleteUserAddress(string addressGuid)
    {
        var addressToDelete = await _context.UserAddresses.FirstOrDefaultAsync(ua => ua.Uuid == Guid.Parse(addressGuid));
        if (addressToDelete == null) return false;

        // Set another address to primary if available
        if (addressToDelete.IsPrimary)
        {
            var nextAddress = _context.UserAddresses.Where(ua => ua.UserId == addressToDelete.UserId).Where(ua => ua.Uuid != addressToDelete.Uuid).First();
            if (nextAddress != null)
            {
                _context.UserAddresses.Update(nextAddress);
                nextAddress.IsPrimary = true;
            }
        }

        _context.UserAddresses.Remove(addressToDelete);
        await _context.SaveChangesAsync();
        return true;
    }
    
    private async Task ResetPrimaryAddress(AppUser user)
    {
        await _context.UserAddresses.Where(ua => ua.UserId == user.Id).ExecuteUpdateAsync(ua => ua.SetProperty(ua => ua.IsPrimary, false));
    }

    private static UserAddressViewDto UserAddressToUserAddressViewDto(UserAddress address)
    {
        return new UserAddressViewDto
        {
            Uuid = address.Uuid,
            Line1 = address.Line1,
            Line2 = address.Line2,
            Country = address.Country,
            City = address.City,
            PostalCode = address.PostalCode,
            IsPrimary = address.IsPrimary,
        };
    }
}
