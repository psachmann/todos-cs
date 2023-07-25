namespace Todos.Core.Features.Todo;

public sealed record class DeleteTodoItemCommand : IRequest
{
    public required Guid Id { get; init; }
}
