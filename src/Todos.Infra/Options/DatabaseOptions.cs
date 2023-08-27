namespace Todos.Infra.Options;

public class DatabaseOptions
{
    public const string SectionName = "Database";

    public required string Connection { get; init; }

    public required string Version { get; init; }
}
