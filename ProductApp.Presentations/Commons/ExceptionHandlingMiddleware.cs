using System.Net;
using System.Text.Json;

namespace ProductApp.WebApi.Commons;

public class ExceptionHandlingMiddleware(RequestDelegate _next,ILogger<ExceptionHandlingMiddleware> _logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception occurred!");

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var result = JsonSerializer.Serialize(new { erorr = ex.Message });
            await context.Response.WriteAsync(result);
        }
    }
}
