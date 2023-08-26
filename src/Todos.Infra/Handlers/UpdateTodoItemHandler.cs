namespace Todos.Infra.Handlers;

internal sealed class UpdateTodoItemHandler : IRequestHandler<UpdateTodoItemCommand, Guid>
{
    private readonly IEntityReader<TodoItemEntity> _reader;
    private readonly IEntityWriter<TodoItemEntity> _writer;

    public UpdateTodoItemHandler(IEntityReader<TodoItemEntity> reader, IEntityWriter<TodoItemEntity> writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public async Task<Guid> Handle(UpdateTodoItemCommand command, CancellationToken cancellationToken)
    {
        var result = await _reader.FindByIdAsync(command.Id, cancellationToken);

        if (result.TryPickT1(out var _, out var todoItem))
        {
            throw new NotFoundException(typeof(TodoItemEntity), command.Id);
        }
        else
        {
            todoItem = todoItem with
            {
                Title = command.Title ?? todoItem.Title,
                Description = command.Description ?? todoItem.Description,
                IsDone = command.Done ?? todoItem.IsDone,
            };

            await _writer.UpdateOneAsync(todoItem, cancellationToken);

            return todoItem.Id;
        }
    }
}
