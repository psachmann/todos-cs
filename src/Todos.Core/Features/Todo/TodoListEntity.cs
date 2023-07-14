namespace Todos.Core.Features.Todo;

public sealed record class TodoListEntity : IEntity
{
    public Guid Id { get; init; }

    public DateTimeOffset CreatedAt { get; init; }

    public DateTimeOffset UpdatedAt { get; init; }

    public string Title { get; init; } = string.Empty;

    public ICollection<TodoItemEntity>? Items { get; init; }
}
