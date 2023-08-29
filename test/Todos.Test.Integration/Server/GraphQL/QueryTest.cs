// namespace Todos.Test.Integration.Server.GraphQL;

// public class QueryTest : IClassFixture<TodosServerFactory>
// {
//     private readonly TodosServerFactory _factory;

//     public QueryTest(TodosServerFactory factory)
//     {
//         _factory = factory;
//     }

//     [Fact]
//     public async Task GetTodoItem_ShouldReturnTodoItem()
//     {
//         var client = _factory.CreateClient();
//         var result = await _client.GetTodoItem.ExecuteAsync();

//         result.IsSuccessResult().Should().BeTrue();
//         result.Data.Should().NotBeNull();
//     }
// }
