using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Todos.Infra.Data.Configurations;

internal abstract class ConfigurationBase<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : class, IEntity
{
    public abstract string TableName { get; }

    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.ToTable(TableName)
            .HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(entity => entity.CreatedAt)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(entity => entity.UpdatedAt)
            .IsRequired()
            .IsRowVersion();
    }
}
