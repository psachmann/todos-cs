using Microsoft.AspNetCore.Mvc.Testing;
using Todos.Server;
using Testcontainers.PostgreSql;

namespace Todos.Test.Integration;

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

    // TODO: configure the web host and other services
    // protected override void ConfigureWebHost
}
