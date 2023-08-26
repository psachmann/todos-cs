namespace Todos.Server.GraphQL;

public sealed class Mutation
{
    public Task<Guid> CreateTodoItemAsync(CreateTodoItemCommand command, [Service] IMediator mediator, CancellationToken cancellationToken)
        => mediator.Send(command, cancellationToken);

    public Task<Guid> UpdateTodoItemAsync(UpdateTodoItemCommand command, [Service] IMediator mediator, CancellationToken cancellationToken)
        => mediator.Send(command, cancellationToken);

    public Task<Guid> DeleteTodoItemAsync(DeleteTodoItemCommand command, [Service] IMediator mediator, CancellationToken cancellationToken)
        => mediator.Send(command, cancellationToken);
}
