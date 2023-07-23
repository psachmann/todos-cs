namespace Todos.Core.Features.Todo;

public sealed record class DeleteTodoItemCommand : IRequest<Unit>
{
    public required Guid Id { get; init; }
}
