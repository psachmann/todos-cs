namespace Todos.Infra.Handlers;

internal sealed class UpdateTodoItemHandler : IRequestHandler<UpdateTodoItemCommand>
{
    private readonly IEntityReader<TodoItemEntity> _reader;
    private readonly IEntityWriter<TodoItemEntity> _writer;

    public UpdateTodoItemHandler(IEntityReader<TodoItemEntity> reader, IEntityWriter<TodoItemEntity> writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public async Task Handle(UpdateTodoItemCommand command, CancellationToken cancellationToken)
    {
        var result = await _reader.FindByIdAsync(command.Id, cancellationToken);

        if (result.TryPickT0(out var todoItem, out var _))
        {
            todoItem = todoItem with
            {
                Title = command.Title ?? todoItem.Title,
                Description = command.Description ?? todoItem.Description,
                Done = command.Done ?? todoItem.Done,
            };

            await _writer.UpdateOneAsync(todoItem, cancellationToken);
        }
        else
        {
            throw new NotFoundException(typeof(TodoItemEntity), command.Id);
        }
    }
}
