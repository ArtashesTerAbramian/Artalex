using Ardalis.Result;
using Artalex.DTO.SessionDtos;

namespace Artalex.BLL.Services.SessionService;

public interface ISessionService
{
    Task<Result<GetCurrentLoginInfoDto>> GetCurrentLoginInfoAsync();
}