using Todos.Core.Specifications;

namespace Todos.Server.GraphQL;

public class Query
{

    public TodoItemEntity GetTodoItem()
        => new()
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Title = $"Title #{1}",
            Description = $"Description #{1}",
        };

    public IEnumerable<TodoItemEntity> TodoItems()
        => Enumerable.Range(0, 10).Select((i) => new TodoItemEntity
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Title = $"Title #{i}",
            Description = $"Description #{i}",
        });

    // public Task<TodoItemEntity> GetTodoItemByIdAsync(FindTodoItemByIdQuery query, [Service] IMediator mediator, CancellationToken cancellationToken)
    //     => mediator.Send(query, cancellationToken);

    // public Task<TodoListEntity> GetTodoListAsync(FindTodoListByIdQuery query, [Service] IMediator mediator, CancellationToken cancellationToken)
    //     => mediator.Send(query, cancellationToken);
}
