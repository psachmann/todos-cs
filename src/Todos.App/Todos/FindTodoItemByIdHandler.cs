using Todos.Core.Features.Todo;

namespace Todos.App.Todos;

internal sealed class FindTodoItemByIdHandler(IEntityReader<TodoItemEntity> reader)
    : IRequestHandler<FindTodoItemByIdQuery, TodoItemEntity>
{
    public async Task<TodoItemEntity> Handle(FindTodoItemByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await reader.FindByIdAsync(query.Id, cancellationToken);

        if (result.TryPickT1(out var _, out var todoItem))
        {
            throw new NotFoundException(typeof(TodoItemEntity), query.Id);
        }
        else
        {
            return todoItem;
        }
    }
}
