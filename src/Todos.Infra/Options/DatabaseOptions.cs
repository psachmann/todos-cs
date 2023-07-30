namespace Todos.Infra.Options;

public class DatabaseOptions
{
    public const string SectionName = "Database";

    public string Connection { get; init; } = string.Empty;
}
