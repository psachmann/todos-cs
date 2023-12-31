namespace Todos.Core.Features.Todo;

public sealed record class CreateTodoItemCommand : IRequest<Guid>
{
    public string Title { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;

    public bool Done { get; init; }
}
