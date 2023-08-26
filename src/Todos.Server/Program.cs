using Todos.Infra.Extensions;
using Todos.Server.GraphQL.Types;

namespace Todos.Server;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddTodosInfra(builder.Configuration)
            .AddGraphQLServer()
            .AddQueryType<QueryType>()
            .AddMutationType<MutationType>();

        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");
        app.MapGraphQL();
        await app.RunAsync();
    }
}
