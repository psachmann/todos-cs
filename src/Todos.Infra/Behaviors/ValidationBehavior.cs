namespace Todos.Infra.Behaviors;

internal sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<ValidationBehavior<TRequest, TResponse>> _logger;
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehavior(ILogger<ValidationBehavior<TRequest, TResponse>> logger, IValidator<TRequest>? validator = default)
    {
        _logger = logger;
        _validator = validator;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validator is not null)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
        }
        else
        {
            _logger.LogWarning("No validator for {Request}", request.GetType().Name);
        }

        return await next();
    }
}
