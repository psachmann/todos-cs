namespace Todos.Core.Features.Todo;

public sealed class FindTodoListByIdQuery : IRequest<TodoListEntity>
{
    public required Guid Id { get; init; }
}
