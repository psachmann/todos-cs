namespace Todos.Infra.Handlers;

internal sealed class DeleteTodoItemHandler : IRequestHandler<DeleteTodoItemCommand>
{
    private readonly IEntityReader<TodoItemEntity> _reader;
    private readonly IEntityWriter<TodoItemEntity> _writer;

    public DeleteTodoItemHandler(IEntityReader<TodoItemEntity> reader, IEntityWriter<TodoItemEntity> writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public async Task Handle(DeleteTodoItemCommand command, CancellationToken cancellationToken)
    {
        var result = await _reader.FindByIdAsync(command.Id, cancellationToken);

        if (result.TryPickT0(out var todoItem, out var _))
        {
            await _writer.DeleteOneAsync(todoItem, cancellationToken);
        }
        else
        {
            throw new NotFoundException(typeof(TodoItemEntity), command.Id);
        }
    }
}
