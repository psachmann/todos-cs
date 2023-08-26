namespace Todos.Infra.Handlers;

internal sealed class FindTodoItemByIdHandler : IRequestHandler<FindTodoItemByIdQuery, TodoItemEntity>
{
    private readonly IEntityReader<TodoItemEntity> _reader;

    public FindTodoItemByIdHandler(IEntityReader<TodoItemEntity> reader)
    {
        _reader = reader;
    }

    public async Task<TodoItemEntity> Handle(FindTodoItemByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _reader.FindByIdAsync(query.Id, cancellationToken);

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
