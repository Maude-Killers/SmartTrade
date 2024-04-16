using System.Net;
using System.Text.Json;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
{
    var code = HttpStatusCode.InternalServerError; // 500 si algo salió mal
    var result = string.Empty;

    switch (exception)
    {
        case ResourceNotFound notFoundException:
            code = HttpStatusCode.NotFound;
            result = JsonSerializer.Serialize(new { error = exception.Message, value = notFoundException.value });
            break;
        
        // default:
        //     result = JsonSerializer.Serialize(new { error = "Un error inesperado ocurrió." });
        //     break;
    }

    context.Response.ContentType = "application/json";
    context.Response.StatusCode = (int)code;
    return context.Response.WriteAsync(result);
}

}
