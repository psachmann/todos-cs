namespace Todos.Test.Integration.Server.GraphQL;

public class QueryTest : IClassFixture<TodosServerFactory>
{
    private readonly ITodosClient _client;

    public QueryTest(TodosServerFactory factory)
    {
        _client = factory.Services.GetRequiredService<ITodosClient>();
    }

    [Fact]
    public async Task GetTodoItem_ShouldReturnTodoItem()
    {
        var result = await _client.GetTodoItem.ExecuteAsync();

        result.IsSuccessResult().Should().BeTrue();
        result.Data.Should().NotBeNull();
    }
}
