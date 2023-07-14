namespace Todos.Core.Abstractions;

public interface IEntityWriter<TEntity>
    where TEntity : class, IEntity
{
    public Task<Guid> CreateOneAsync(TEntity entity);

    public Task<IEnumerable<Guid>> CreateManyAsync(IEnumerable<TEntity> entities);

    public Task UpdateOneAsync(TEntity entity);

    public Task UpdateManyAsync(IEnumerable<TEntity> entities);

    public Task DeleteOneAsync(TEntity entity);

    public Task DeleteManyAsync(IEnumerable<TEntity> entities);
}
