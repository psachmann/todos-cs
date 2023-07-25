namespace Todos.Core.Exceptions;

public sealed class NotFoundException : Exception
{
    public NotFoundException(Type type, Guid id)
        : base($"{type.Name} not found ({id})")
    {
    }
}
