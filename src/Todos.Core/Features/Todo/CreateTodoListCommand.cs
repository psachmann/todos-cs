namespace Todos.Core.Features.Todo;

public sealed record class CreateTodoListCommand : IRequest<Guid>
{
    public string Title { get; init; } = string.Empty;

    public ICollection<TodoItemEntity>? Items { get; init; }
}
