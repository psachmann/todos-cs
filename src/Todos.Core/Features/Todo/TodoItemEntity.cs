namespace Todos.Core.Features.Todo;

/// <summary>
/// The representation of a todo item.
/// </summary>
public sealed record class TodoItemEntity : IEntity
{
    /// <summary>
    /// The id of the todo item.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// The creation date of the todo item.
    /// </summary>
    public DateTimeOffset CreatedAt { get; init; }

    /// <summary>
    /// The last updated date of the todo item.
    /// </summary>
    public DateTimeOffset UpdatedAt { get; init; }

    /// <summary>
    /// The title of the todo item.
    /// Can be an empty string.
    /// </summary>
    public string Title { get; init; } = string.Empty;

    /// <summary>
    /// The description of the todo item.
    /// Can be an empty string.
    /// </summary>
    public string Description { get; init; } = string.Empty;

    /// <summary>
    /// Indicates whether the todo item is done or not.
    /// Default value is false.
    /// </summary>
    public bool IsDone { get; init; }
}
