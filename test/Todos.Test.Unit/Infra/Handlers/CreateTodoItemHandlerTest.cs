namespace Todos.Test.Unit.Infra.Handlers;

public class CreateTodoItemHandlerTest
{
    private readonly CreateTodoItemHandler _sut;
    private readonly IEntityWriter<TodoItemEntity> _writerMock;
    private readonly IMapper _mapperMock;

    public CreateTodoItemHandlerTest()
    {
        _writerMock = Substitute.For<IEntityWriter<TodoItemEntity>>();
        _mapperMock = Substitute.For<IMapper>();
        _sut = new CreateTodoItemHandler(_writerMock, _mapperMock);
    }

    [Fact]
    public async Task Handle_ShouldCreateNewTodoItem()
    {
        var command = new CreateTodoItemCommand();
        _mapperMock.Map<TodoItemEntity>(Arg.Any<CreateTodoItemCommand>())
            .Returns(new TodoItemFaker().Generate());
        _writerMock.CreateOneAsync(Arg.Any<TodoItemEntity>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(new TodoItemFaker(true).Generate().Id));

        var result = await _sut.Handle(command, default);

        result.Should().NotBeEmpty();
        _mapperMock.ReceivedWithAnyArgs().Map<TodoItemEntity>(default);
        await _writerMock.ReceivedWithAnyArgs().CreateOneAsync(default!, default);
    }
}
