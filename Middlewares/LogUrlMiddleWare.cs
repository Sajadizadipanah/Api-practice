using Microsoft.AspNetCore.Builder;

namespace API_Practice.Middlewares;

public class LogUrlMiddleWare
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LogUrlMiddleWare> _logger;

    public LogUrlMiddleWare(RequestDelegate next, ILogger<LogUrlMiddleWare> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation($"Request Url:{Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(context.Request)}");
        await this._next(context);
    }
}

public static class LogUrlExtention
{
    public static IApplicationBuilder UseLogUrl(this IApplicationBuilder app)
    {
        return app.UseMiddleware<LogUrlMiddleWare>();
    }
}
