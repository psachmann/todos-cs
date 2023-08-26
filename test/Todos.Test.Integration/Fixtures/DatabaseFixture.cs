using DotNet.Testcontainers.Containers;
using Testcontainers.PostgreSql;

namespace Todos.Test.Integration.Fixtures;

public sealed class DatabaseFixture : IAsyncLifetime
{
    private readonly PostgreSqlContainer _database;

    public DatabaseFixture()
    {
        _database = new PostgreSqlBuilder()
            .WithImage("postgres:15.3-alpine")
            .WithDatabase("todos")
            .WithUsername("admin")
            .WithPassword("password")
            .Build();
    }

    public string ConnectionString => _database.GetConnectionString();

    public async Task InitializeAsync()
    {
        await _database.StartAsync();
    }

    public async Task DisposeAsync()
    {
        await _database.StopAsync();
    }
}
