using FluentValidation;
using System.Net;
using System.Text.Json;

namespace ProductApp.WebApi.Commons;

public class ValidationExceptionMiddleware(RequestDelegate _next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var errors = ex.Errors.Select(x => new
            {
                PropertyName = x.PropertyName,
                ErrorMessage = x.ErrorMessage
            });

            var result = JsonSerializer.Serialize(errors, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            await context.Response.WriteAsync(result);
        }
    }
}
