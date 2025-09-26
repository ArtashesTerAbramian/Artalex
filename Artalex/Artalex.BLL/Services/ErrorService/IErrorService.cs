using Artalex.DTO;

namespace Artalex.BLL.Services.ErrorService;

public interface IErrorService
{
    Task<ErrorModelDto> GetById(long id);
}