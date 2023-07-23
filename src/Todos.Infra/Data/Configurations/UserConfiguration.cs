using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Todos.Infra.Data.Configurations;

internal sealed class UserConfiguration : ConfigurationBase<UserEntity>
{
    public override string TableName => "users";

    public override void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        base.Configure(builder);

        builder.Property(user => user.Email)
            .IsRequired()
            .HasMaxLength(Limits.MaxShortString);

        builder.Property(user => user.EmailNormalized)
            .IsRequired()
            .HasMaxLength(Limits.MaxShortString);

        builder.HasIndex(user => user.EmailNormalized)
            .IsUnique();

        builder.Property(user => user.PasswordHash)
            .IsRequired()
            .HasMaxLength(Limits.MaxShortString);

        builder.Property(user => user.PasswordSalt)
            .IsRequired()
            .HasMaxLength(Limits.MaxShortString);

        builder.Property(user => user.DisplayName)
            .IsRequired()
            .HasMaxLength(Limits.MaxShortString);
    }
}
