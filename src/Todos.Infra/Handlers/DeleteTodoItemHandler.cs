namespace Todos.Infra.Handlers;

internal sealed class DeleteTodoItemHandler(IEntityReader<TodoItemEntity> reader, IEntityWriter<TodoItemEntity> writer)
    : IRequestHandler<DeleteTodoItemCommand, Guid>
{
    public async Task<Guid> Handle(DeleteTodoItemCommand command, CancellationToken cancellationToken)
    {
        var result = await reader.FindByIdAsync(command.Id, cancellationToken);

        if (result.TryPickT1(out var _, out var todoItem))
        {
            throw new NotFoundException(typeof(TodoItemEntity), command.Id);
        }
        else
        {
            await writer.DeleteOneAsync(todoItem, cancellationToken);

            return todoItem.Id;
        }
    }
}
