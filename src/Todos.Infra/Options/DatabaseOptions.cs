namespace Todos.Infra.Options;

public class DatabaseOptions
{
    public const string SectionName = "Database";

    public required string Uri { get; init; }

    public required string Database { get; init; }

    public required string Username { get; init; }

    public required string Password { get; init; }

    public string Connection => $"Host={Uri};Database={Database};Username={Username};Password={Password};";
}
