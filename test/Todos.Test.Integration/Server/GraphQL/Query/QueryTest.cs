namespace Todos.Test.Integration.Server.GraphQL;

public class QueryTest : IClassFixture<TodosServerFixture>
{
    private readonly TodosServerFixture _fixture;

    public QueryTest(TodosServerFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task GetTodoItem_ShouldReturnTodoItem()
    {
        var result = await _fixture.ExecuteQueryAsync((request) => request.SetQuery(
            """
            {
                todoItem {
                    id,
                    title,
                    isDone,
                }
            }
            """));

        result.Should().NotBeNull();
        result.MatchSnapshot();
    }

    [Fact]
    public async Task GetTodoList_ShouldReturnTodoList()
    {
        var id = Guid.NewGuid();
        var result = await _fixture.ExecuteQueryAsync((request) => request.SetQuery(
            $$""""
            {
                todoList(query: { {{id}} }) {
                    id,
                    title,
                    isDone,
                }
            }
            """"));

        result.Should().NotBeNull();
        result.MatchSnapshot();
    }
}
