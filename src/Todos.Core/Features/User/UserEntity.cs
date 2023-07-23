namespace Todos.Core.Features.User;

public sealed record class UserEntity : IEntity
{
    public Guid Id { get; init; }

    public DateTimeOffset CreatedAt { get; init; }

    public DateTimeOffset UpdatedAt { get; init; }

    public required string Email { get; init; }

    public required string EmailNormalized { get; init; }

    public required string PasswordHash { get; init; }

    public required string PasswordSalt { get; init; }

    public string DisplayName { get; init; } = string.Empty;
}
