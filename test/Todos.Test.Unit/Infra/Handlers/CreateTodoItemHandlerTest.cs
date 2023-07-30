namespace Todos.Test.Unit.Infra.Handlers;

public class CreateTodoItemHandlerTest
{
    private readonly CreateTodoItemHandler _sut;
    private readonly Mock<IEntityWriter<TodoItemEntity>> _writerMock;
    private readonly Mock<IMapper> _mapperMock;

    public CreateTodoItemHandlerTest()
    {
        _writerMock = new Mock<IEntityWriter<TodoItemEntity>>();
        _mapperMock = new Mock<IMapper>();
        _sut = new CreateTodoItemHandler(_writerMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldCreateNewTodoItem()
    {
        var command = new CreateTodoItemCommand();
        _mapperMock.Setup((mapper) => mapper.Map<TodoItemEntity>(It.IsAny<CreateTodoItemCommand>()))
            .Returns(new TodoItemFaker().Generate());
        _writerMock.Setup((writer) => writer.CreateOneAsync(It.IsAny<TodoItemEntity>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new TodoItemFaker(true).Generate().Id);

        var result = await _sut.Handle(command, default);

        result.Should().NotBeEmpty();
        _mapperMock.Verify((mapper) => mapper.Map<TodoItemEntity>(It.IsAny<CreateTodoItemCommand>()), Times.Once);
        _writerMock.Verify((writer) => writer.CreateOneAsync(It.IsAny<TodoItemEntity>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
