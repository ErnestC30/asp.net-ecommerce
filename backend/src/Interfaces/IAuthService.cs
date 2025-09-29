using backend.Models;

namespace backend.Interfaces;

public interface IAuthService
{
    public Task<LoginRegisterResponse> LoginUser(string email, string password);
    public Task<LoginRegisterResponse> LogoutUser(string userId, string? refreshToken);
    public Task<LoginRegisterResponse> RegisterUser(string email, string password);
    public Task DeleteUser(string userId);
    public HttpResponse CreateOrUpdateJwtTokenCookies(HttpResponse response, string jwtToken, DateTime jwtTokenExpire, string jwtResponseToken, DateTime jwtResponseTokenExpire);
    public HttpResponse RemoveJwtTokenCookies(HttpResponse response);
    public Task<LoginRegisterResponse> RefreshJwtToken(string userId, string refreshToken);

}
