namespace Todos.Core.Abstractions;

public interface IEntityWriter<TEntity>
    where TEntity : class, IEntity
{
    public Task<Guid> CreateOneAsync(TEntity entity, CancellationToken cancellationToken = default);

    public Task<IEnumerable<Guid>> CreateManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

    public Task UpdateOneAsync(TEntity entity, CancellationToken cancellationToken = default);

    public Task UpdateManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

    public Task DeleteOneAsync(TEntity entity, CancellationToken cancellationToken = default);

    public Task DeleteManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
}
