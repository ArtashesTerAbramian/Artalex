using Ardalis.Result;
using Artalex.DTO.LoginDtos;

namespace Artalex.BLL.Services.AuthService;

public interface IAuthService
{
    Task<Result<LoginResultDto>> LoginAsync(LoginDto dto);
    Task LogoutAsync();
}