namespace Todos.Core.Features.Todo;

public sealed record class UpdateTodoItemCommand : IRequest
{
    public required Guid Id { get; init; }

    public string? Title { get; init; }

    public string? Description { get; init; }

    public bool? Done { get; init; }
}
