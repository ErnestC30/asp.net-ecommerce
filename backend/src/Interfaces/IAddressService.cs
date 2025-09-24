using backend.Models;
using backend.Models.AccountDto;

namespace backend.Interfaces;

public interface IAddressService
{
    public Task<ICollection<UserAddressViewDto>> GetUserAddresses(string userId);
    public Task<UserAddress> CreateUserAddress(UserAddressCreateDto createDto, string userId);
    public Task<UserAddress> EditUserAddress(UserAddressEditDto editDto, string addressGuid, string userId);
    public Task<bool> DeleteUserAddress(string addressGuid);
}
