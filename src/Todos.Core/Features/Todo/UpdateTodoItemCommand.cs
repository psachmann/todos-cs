namespace Todos.Core.Features.Todo;

public sealed record class UpdateTodoItemCommand : IRequest<Unit>
{
    public string Title { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;

    public bool Done { get; init; }
}
