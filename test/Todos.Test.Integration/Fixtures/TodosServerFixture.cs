using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Testcontainers.MariaDb;
using Todos.Server;

namespace Todos.Test.Integration.Fixtures;

public sealed class TodosServerFixture : WebApplicationFactory<Program>, IAsyncLifetime
{
    // TODO: remove this hard coded value
    private const string MariaDbVersion = "11.0";
    private readonly MariaDbContainer _mariaDb;

    public TodosServerFixture()
    {
        _mariaDb = new MariaDbBuilder()
            .WithImage($"mariadb:{MariaDbVersion}")
            .WithDatabase("todos")
            .WithUsername("admin")
            .WithPassword("password")
            .Build();
    }

    public async Task InitializeAsync()
    {
        await _mariaDb.StartAsync();
    }

    public async new Task DisposeAsync()
    {
        await _mariaDb.StopAsync();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices((services) =>
        {
            OverrideDatabaseConfiguration(services);
            OverrideGraphQLConfiguration(services);
        });
    }

    private void OverrideDatabaseConfiguration(IServiceCollection services)
    {
        services.RemoveAll<DatabaseOptions>();
        services.AddSingleton<DatabaseOptions>((_) => new()
        {
            Connection = _mariaDb.GetConnectionString(),
            Version = MariaDbVersion,
        });
    }

    private void OverrideGraphQLConfiguration(IServiceCollection services)
    {
        services.AddSingleton<RequestExecutorProxy>((services) => new(services.GetRequiredService<IRequestExecutorResolver>(), Schema.DefaultName));
    }
}
