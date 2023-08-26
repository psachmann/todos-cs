namespace Todos.Core.Features.Todo;

/// <summary>
/// The representation of a collection of todo items.
/// </summary>
public sealed record class TodoListEntity : IEntity
{
    /// <summary>
    /// The id of the todo list.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// The creation date of the todo list.
    /// </summary>
    public DateTimeOffset CreatedAt { get; init; }

    /// <summary>
    /// The last updated date of the todo list.
    /// </summary>
    public DateTimeOffset UpdatedAt { get; init; }

    /// <summary>
    /// The title of the todo list.
    /// </summary>
    public string Title { get; init; } = string.Empty;

    /// <summary>
    /// The todo items associated with the todo list.
    /// </summary>
    /// <value></value>
    public ICollection<TodoItemEntity>? Items { get; init; }
}
