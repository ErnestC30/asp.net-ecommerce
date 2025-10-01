using backend.Models;
using backend.Models.AccountDto;

namespace backend.Interfaces;

public interface IAddressService
{
    public Task<AppUser> GetAppUser(string userId);
    public Task<ICollection<UserAddressViewDto>> GetUserAddresses(AppUser user);
    public Task<UserAddress> CreateUserAddress(UserAddressCreateDto createDto, AppUser user);
    public Task<UserAddress> EditUserAddress(UserAddressEditDto editDto, string addressGuid, AppUser user);
    public Task<bool> DeleteUserAddress(string addressGuid);
}
