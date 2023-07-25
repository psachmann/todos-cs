using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;

namespace Todos.Test.Integration.Fixtures;

public sealed class DatabaseFixture : IAsyncLifetime
{
    private readonly IContainer database;

    public DatabaseFixture()
    {
        database = new ContainerBuilder()
            .WithImage("docker.io/postgres:15.3-alpine")
            .WithPortBinding(5432)
            .WithEnvironment("POSTGRE_USERNAME", "admin")
            .WithEnvironment("POSTGRE_PASSWORD", "password")
            .WithEnvironment("POSTGRE_DB", "todos")
            .WithCleanUp(true)
            .Build();
    }

    public async Task InitializeAsync()
    {
        await database.StartAsync();
    }

    public async Task DisposeAsync()
    {
        await database.StopAsync();
    }
}
