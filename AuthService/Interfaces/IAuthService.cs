using AuthService.Dtos;
using AuthService.ResponseModels;

namespace AuthService.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterAsync(RegisterDto dto);
        Task<AuthResponse> LoginAsync(LoginDto dto);

    }
}