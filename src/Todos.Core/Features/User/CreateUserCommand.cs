namespace Todos.Core.Features.User;

public sealed class CreateUserCommand : IRequest<Guid>
{
    public required string Email { get; init; }

    public required string Password { get; init; }

    public string? DisplayName { get; init; }
}
