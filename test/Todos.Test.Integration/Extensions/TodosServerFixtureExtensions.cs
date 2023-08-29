namespace Todos.Test.Integration.Extensions;

public static class TodosServerFixtureExtensions
{
    public static async Task<string> ExecuteQueryAsync(this TodosServerFixture fixture, Action<IQueryRequestBuilder> configureRequest, CancellationToken cancellationToken = default)
    {
        await using var scope = fixture.Services.CreateAsyncScope();
        var executor = fixture.Services.GetRequiredService<RequestExecutorProxy>();
        var requestBuilder = new QueryRequestBuilder();

        requestBuilder.SetServices(scope.ServiceProvider);
        configureRequest(requestBuilder);

        var request = requestBuilder.Create();
        await using var result = await executor.ExecuteAsync(request, cancellationToken);

        result.ExpectQueryResult();

        return result.ToJson();
    }
}
