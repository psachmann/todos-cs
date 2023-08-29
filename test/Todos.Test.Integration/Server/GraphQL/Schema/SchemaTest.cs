namespace Todos.Server.GraphQL;

public class SchemaTest
{
    [Fact]
    public async Task SchemeChangeTest()
    {
        var schema = await new ServiceCollection()
            .AddGraphQLServer()
            .AddQueryType<QueryType>()
            .BuildSchemaAsync();

        schema.Should().NotBeNull();
        schema.ToString().MatchSnapshot();
    }
}
