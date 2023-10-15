namespace Todos.Infra.Handlers;

internal sealed class UpdateTodoItemHandler(IEntityReader<TodoItemEntity> reader, IEntityWriter<TodoItemEntity> writer)
    : IRequestHandler<UpdateTodoItemCommand, Guid>
{
    public async Task<Guid> Handle(UpdateTodoItemCommand command, CancellationToken cancellationToken)
    {
        var result = await reader.FindByIdAsync(command.Id, cancellationToken);

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

            await writer.UpdateOneAsync(todoItem, cancellationToken);

            return todoItem.Id;
        }
    }
}
