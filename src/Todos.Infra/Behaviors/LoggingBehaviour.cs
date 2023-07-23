namespace Todos.Infra.Behaviors;

internal sealed class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = nameof(TRequest);
        var responseName = nameof(TResponse);

        _logger.LogInformation("Processing {RequestName}...", requestName);
        _logger.LogDebug("Processing {RequestPayload}...", request);

        var response = await next();

        _logger.LogInformation("Processed {RequestName} and responding with {ResponseName}", requestName, responseName);
        _logger.LogDebug("Responding {ResponsePayload}", response);

        return response;
    }
}
