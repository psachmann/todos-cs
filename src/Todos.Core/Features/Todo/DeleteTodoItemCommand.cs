namespace Todos.Core.Features.Todo;

public sealed record class DeleteTodoItemCommand : IRequest<Guid>
{
    public required Guid Id { get; init; }
}
