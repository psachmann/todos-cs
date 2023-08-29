using Todos.Infra.Extensions;
using Todos.Server.GraphQL.Types;
using Todos.Server.Middlewares;

namespace Todos.Server;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddTodosInfra(builder.Configuration)
            .AddLogging()
            .AddTransient<GlobalExceptionMiddleware>()
            .AddGraphQLServer()
            .AddQueryType<QueryType>()
            .AddMutationType<MutationType>();

        var app = builder.Build();

        app.UseMiddleware<GlobalExceptionMiddleware>();

        app.MapGet("/", () => "Hello World!");
        app.MapGraphQL();
        await app.RunAsync();
    }
}
