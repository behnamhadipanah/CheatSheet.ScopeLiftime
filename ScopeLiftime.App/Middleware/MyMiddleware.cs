using ScopeLiftime.Logic.Interfaces;

namespace ScopeLiftime.App.Middleware;

public class MyMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;
    public readonly ISingletonService _singletonService;
    public MyMiddleware(RequestDelegate next, ILogger<MyMiddleware> logger,
        ISingletonService singletonService)
    {
        _logger = logger;
        _singletonService = singletonService;
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context,
        IScopedService scopedService, ITransientService transientService)
    {
        _logger.LogInformation("Transient: " + transientService.InstanceId);
        _logger.LogInformation("Scoped: " + scopedService.InstanceId);
        _logger.LogInformation("Singleton: " + _singletonService.InstanceId);
        _logger.LogInformation("--------------------------------------------------");
        await _next(context);
    }
}