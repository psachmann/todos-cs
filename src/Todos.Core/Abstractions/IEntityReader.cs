using System.Threading;

namespace Todos.Core.Abstractions;

public interface IEntityReader<TEntity>
    where TEntity : class, IEntity
{
    public Task<OneOf<TEntity, Unit>> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<OneOf<TEntity, Unit>> FindOneAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);

    public Task<OneOf<IEnumerable<TEntity>>> FindManyAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);
}
