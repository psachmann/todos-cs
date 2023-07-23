namespace Todos.Core.Features.Todo;

public sealed record class UpdateTodoListCommand : IRequest<Unit>
{
    public string? Title { get; init; }

    public ICollection<TodoItemEntity>? Items { get; init; }
}
