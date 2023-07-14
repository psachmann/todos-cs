namespace Todos.Core.Abstractions;

public interface IEntity
{
    public Guid Id { get; }

    public DateTimeOffset CreatedAt { get; }

    public DateTimeOffset UpdatedAt { get; }
}
