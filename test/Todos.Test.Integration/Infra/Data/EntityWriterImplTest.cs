using Todos.Core.Abstractions;
using Todos.Core.Features.Todo;

namespace Todos.Test.Integration.Infra.Data;

public class EntityWriterImplTest : IClassFixture<TodosServerFactory>, IAsyncLifetime
{
    private readonly IEntityWriter<TodoItemEntity> _sut;
    private readonly TodosContext _context;

    public EntityWriterImplTest(TodosServerFactory factory)
    {
        _sut = factory.Services.GetRequiredService<IEntityWriter<TodoItemEntity>>();
        _context = factory.Services.GetRequiredService<TodosContext>();
    }

    public async Task InitializeAsync()
    {
        await _context.Database.EnsureCreatedAsync();
    }

    public async Task DisposeAsync()
    {
        await _context.Database.EnsureDeletedAsync();
    }

    [Fact]
    public async Task CreateOneAsync_ReturnsGeneratedId_WhenEntityWasCreated()
    {
        var faker = new TodoItemFaker();
        var todoItem = faker.Generate();

        todoItem.Id.Should().Be(Guid.Empty);

        var result = await _sut.CreateOneAsync(todoItem);

        result.Should().NotBe(Guid.Empty);
    }
}
