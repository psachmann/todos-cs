using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Testcontainers.MariaDb;
using Todos.Server;

namespace Todos.Test.Integration.Fixtures;

public sealed class TodosServerFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly MariaDbContainer _mariaDb;

    public TodosServerFactory()
    {
        _mariaDb = new MariaDbBuilder()
            .WithImage("mariadb:11.0")
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
            services
                .AddTodosClient()
                // TODO: remove hardcoded base uri
                .ConfigureHttpClient((client) => client.BaseAddress = new Uri($"{Server.BaseAddress}/graphql"));

            OverrideDatabaseConfiguration(services);
        });
    }

    private void OverrideDatabaseConfiguration(IServiceCollection services)
    {
        services.RemoveAll<DatabaseOptions>();
        services.AddSingleton<DatabaseOptions>((_) => new()
        {
            Connection = _mariaDb.GetConnectionString(),
            // TODO: remove this hard coded value
            Version = "11.0",
        });
    }
}
