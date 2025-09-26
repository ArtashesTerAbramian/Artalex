using Ardalis.Result;
using Artalex.BLL.Constants;
using Artalex.BLL.Services.ErrorService;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Artalex.BLL.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext context, ILogger<ErrorHandlingMiddleware> logger)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, logger);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex, ILogger<ErrorHandlingMiddleware> logger)
    {
        context.Response.ContentType = "application/json";
        Result responseResult;

        var errorService = context.RequestServices.GetRequiredService<IErrorService>();
        if (ex is DbUpdateException dbExceptin && dbExceptin.InnerException is Npgsql.PostgresException inEx &&
            inEx.SqlState == "23505")
        {
            //23505 unique key violates exception
            responseResult = Result.Error((await errorService.GetById(ErrorConstants.DuplicateItem)).Description);
            logger.LogError(ex, "ErrorHandlingMiddleware Db_Error");
        }

        else if (ex is DbUpdateException)
        {
            responseResult = Result.Error((await errorService.GetById(ErrorConstants.CannotRemoveDataWithReference))
                .Description);
            logger.LogError(ex, "ErrorHandlingMiddleware Db_Error");
        }
        else
        {
            responseResult = Result.Error("Oops! Something went wrong");
            logger.LogError(ex, "ErrorHandlingMiddleware");
        }

        context.Response.StatusCode = 500;

        var result = JsonSerializer.Serialize(responseResult, new JsonSerializerOptions()
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase
        });

        await context.Response.WriteAsync(result);
    }
}