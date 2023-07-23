namespace Todos.Core.Features.Todo;

public sealed record class DeleteTodoListCommand : IRequest<Unit>
{
    public required Guid Id { get; init; }
}
