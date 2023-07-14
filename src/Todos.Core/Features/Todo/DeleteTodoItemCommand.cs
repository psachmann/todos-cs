namespace Todos.Core.Features.Todo;

public sealed class DeleteTodoItemCommand : IRequest<Unit>
{
    public required Guid Id { get; init; }
}
