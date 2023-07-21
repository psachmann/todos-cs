namespace Todos.Infra.Services;

internal sealed class ClockImpl : IClock, ISingleton
{
    public DateTimeOffset CurrentUtc => DateTimeOffset.UtcNow;

    public DateOnly CurrentDate => DateOnly.FromDateTime(CurrentUtc.DateTime);

    public TimeOnly CurrentTime => TimeOnly.FromDateTime(CurrentUtc.DateTime);
}
