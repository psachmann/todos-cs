namespace Todos.Core.Features.Todo;

public sealed class UpdateTodoItemCommand : IRequest<Unit>
{
    public string Title { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;

    public bool Done { get; init; }
}
