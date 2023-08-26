namespace Todos.Server.GraphQL;

internal static class SchemaUtils
{
    private const string EntityPostfix = "Entity";

    public static string GetEntityQueryName<TEntity>()
        => typeof(TEntity).Name[..^EntityPostfix.Length];
}
