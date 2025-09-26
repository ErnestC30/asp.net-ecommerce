using backend.Models;

namespace backend.Interfaces;

public interface IAuthService
{
    public Task<LoginRegisterResponse> LoginUser(string email, string password);
    public Task<LoginRegisterResponse> RegisterUser(string email, string password);
    public Task DeleteUser(string userId);
    public HttpResponse AddTokensToCookie(HttpResponse response, string jwtToken, DateTime jwtTokenExpire, string jwtResponseToken, DateTime jwtResponseTokenExpire);
}
