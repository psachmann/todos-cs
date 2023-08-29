using System.Net;

namespace Todos.Server.Middlewares;

public class GlobalExceptionMiddleware
{
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(ILogger<GlobalExceptionMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, Func<Task> next)
    {
        try
        {
            await next();
        }
        catch (Exception error)
        {
            _logger.LogCritical("{Error}", error);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsJsonAsync(new { StatusCode = HttpStatusCode.InternalServerError, Message = "Internal Server Error :(" });
        }
    }
}
