using Artalex.DAL;
using Artalex.DTO;
using Microsoft.EntityFrameworkCore;

namespace Artalex.BLL.Services.ErrorService;

public class ErrorService : IErrorService
{
    private readonly AppDbContext _db;

    public ErrorService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<ErrorModelDto> GetById(long id)
    {
        var error = await _db.Errors.FirstOrDefaultAsync(x => x.Id == id);

        return new ErrorModelDto()
        {
            Code = error.Id,
            Description = error.Name
        };
    }
}