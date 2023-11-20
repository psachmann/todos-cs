namespace Todos.App.Todos;

internal sealed class CreateTodoItemHandler(IEntityWriter<TodoItemEntity> writer, IMapper mapper)
     : IRequestHandler<CreateTodoItemCommand, Guid>
{
    public async Task<Guid> Handle(CreateTodoItemCommand command, CancellationToken cancellationToken)
    {
        var todoItem = mapper.Map<TodoItemEntity>(command);
        var todoItemId = await writer.CreateOneAsync(todoItem, cancellationToken);

        return todoItemId;
    }
}
