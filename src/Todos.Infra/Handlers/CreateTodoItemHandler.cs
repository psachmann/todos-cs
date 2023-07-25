namespace Todos.Infra.Handlers;

internal sealed class CreateTodoItemHandler : IRequestHandler<CreateTodoItemCommand, Guid>
{
    private readonly IEntityWriter<TodoItemEntity> _writer;
    private readonly IMapper _mapper;

    public CreateTodoItemHandler(IEntityWriter<TodoItemEntity> writer, IMapper mapper)
    {
        _writer = writer;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateTodoItemCommand command, CancellationToken cancellationToken)
    {
        var todoItem = _mapper.Map<TodoItemEntity>(command);
        var todoItemId = await _writer.CreateOneAsync(todoItem, cancellationToken);

        return todoItemId;
    }
}
