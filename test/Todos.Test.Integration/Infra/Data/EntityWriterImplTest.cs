using Todos.Core.Abstractions;
using Todos.Core.Features.Todo;

namespace Todos.Test.Integration.Infra.Data;

public class EntityWriterImplTest : IClassFixture<TodosServerFixture>, IAsyncLifetime
{
    private readonly IEntityWriter<TodoItemEntity> _sut;
    private readonly TodosContext _context;

    public EntityWriterImplTest(TodosServerFixture factory)
    {
        var provider = factory.Services.CreateScope().ServiceProvider;

        _sut = provider.GetRequiredService<IEntityWriter<TodoItemEntity>>();
        _context = provider.GetRequiredService<TodosContext>();
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
        var todoItem = faker.Generate(TodoItemFaker.RuleSetNotPersisted);

        Console.WriteLine(todoItem);
        todoItem.Id.Should().Be(Guid.Empty);

        var result = await _sut.CreateOneAsync(todoItem);

        result.Should().NotBe(Guid.Empty);
    }
}
