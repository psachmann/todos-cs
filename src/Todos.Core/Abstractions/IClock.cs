namespace Todos.Core.Abstractions;

public interface IClock
{
    public DateTimeOffset CurrentUtc { get; }

    public DateOnly CurrentDate { get; }

    public TimeOnly CurrentTime { get; }
}
