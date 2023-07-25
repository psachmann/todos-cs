namespace Todos.Test.Integration.Fixtures;

public sealed class DIFixture : IDisposable
{
    private static readonly IServiceProvider Root = new ServiceCollection()
        .AddTodosInfra(new ConfigurationBuilder().Build())
        .BuildServiceProvider();

    private readonly IServiceScope _scope;

    public DIFixture()
    {
        _scope = Root.CreateScope();
    }

    public IServiceProvider ServiceProvider => _scope.ServiceProvider;

    public void Dispose()
    {
        _scope.Dispose();
    }
}
