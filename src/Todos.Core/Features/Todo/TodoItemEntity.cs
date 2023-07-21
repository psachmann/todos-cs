namespace Todos.Core.Features.Todo;

public sealed class FindByIdTodoItemQuery : IRequest<TodoItemEntity>
{
    public required Guid Id { get; init; }
}

public sealed record class TodoItemEntity : IEntity
{
    public Guid Id { get; init; }

    public DateTimeOffset CreatedAt { get; init; }

    public DateTimeOffset UpdatedAt { get; init; }

    public string Title { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;

    public bool Done { get; init; }
}
