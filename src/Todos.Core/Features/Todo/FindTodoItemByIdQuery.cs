namespace Todos.Core.Features.Todo;

public sealed class FindTodoItemByIdQuery : IRequest<TodoItemEntity>
{
    public required Guid Id { get; init; }
}
