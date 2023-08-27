using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Testcontainers.PostgreSql;
using Todos.Server;

namespace Todos.Test.Integration.Fixtures;

public sealed class TodosServerFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgres;

    public TodosServerFactory()
    {
        _postgres = new PostgreSqlBuilder()
            .WithImage("postgres:15.3-alpine")
            .WithDatabase("todos")
            .WithUsername("admin")
            .WithPassword("password")
            .Build();
    }


    public async Task InitializeAsync()
    {
        await _postgres.StartAsync();
    }

    public async new Task DisposeAsync()
    {
        await _postgres.StopAsync();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices((services) =>
        {
            services
                .AddTodosClient()
                // TODO: remove hardcoded base uri
                .ConfigureHttpClient((client) => client.BaseAddress = new Uri("http://127.0.0.1:5218/graphql"));

            OverrideDatabaseConfiguration(services);
        });
    }

    private void OverrideDatabaseConfiguration(IServiceCollection services)
    {
        services.RemoveAll<DatabaseOptions>();
        services.AddSingleton<DatabaseOptions>((_) => new()
        {
            Connection = _postgres.GetConnectionString(),
            // TODO: remove this hard coded value
            Version = "15.3",
        });
    }
}
