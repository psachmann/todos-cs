namespace Todos.Infra.Handlers;

internal sealed class DeleteTodoItemHandler : IRequestHandler<DeleteTodoItemCommand, Guid>
{
    private readonly IEntityReader<TodoItemEntity> _reader;
    private readonly IEntityWriter<TodoItemEntity> _writer;

    public DeleteTodoItemHandler(IEntityReader<TodoItemEntity> reader, IEntityWriter<TodoItemEntity> writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public async Task<Guid> Handle(DeleteTodoItemCommand command, CancellationToken cancellationToken)
    {
        var result = await _reader.FindByIdAsync(command.Id, cancellationToken);

        if (result.TryPickT1(out var _, out var todoItem))
        {
            throw new NotFoundException(typeof(TodoItemEntity), command.Id);
        }
        else
        {
            await _writer.DeleteOneAsync(todoItem, cancellationToken);

            return todoItem.Id;
        }
    }
}
