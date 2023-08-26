using Todos.Core.Specifications;

namespace Todos.Server.GraphQL;

public class Query
{
    public async Task<IEnumerable<TodoItemEntity>> GetAllTodoItemsAsync([Service] IEntityReader<TodoItemEntity> reader, CancellationToken cancellationToken)
    {
        var result = await reader.FindManyAsync(new FindAllSpecification<TodoItemEntity>(), cancellationToken);
        return result.AsT0;
    }

    public Task<TodoItemEntity> GetTodoItemAsync(FindTodoItemByIdQuery query, [Service] IMediator mediator, CancellationToken cancellationToken)
        => mediator.Send(query, cancellationToken);

    public Task<TodoListEntity> GetTodoListAsync(FindTodoListByIdQuery query, [Service] IMediator mediator, CancellationToken cancellationToken)
        => mediator.Send(query, cancellationToken);
}
