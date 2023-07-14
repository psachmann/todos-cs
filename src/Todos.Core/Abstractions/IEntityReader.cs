namespace Todos.Core.Abstractions;

public interface IEntityReader<TEntity>
    where TEntity : class, IEntity
{
    public Task<OneOf<TEntity, Unit>> FindByIdAsync(Guid id);

    public Task<OneOf<TEntity, Unit>> FindOneAsync(ISpecification<TEntity> specification);

    public Task<OneOf<IEnumerable<TEntity>>> FindManyAsync(ISpecification<TEntity> specification);
}
