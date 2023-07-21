namespace Todos.Infra.Data;

internal sealed class EntityReaderImpl<TEntity> : IEntityReader<TEntity>, ITransient
    where TEntity : class, IEntity
{
    private readonly TodosContext _context;

    public EntityReaderImpl(TodosContext context)
    {
        _context = context;
    }

    public async Task<OneOf<TEntity, Unit>> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Set<TEntity>()
            .FindAsync(id, cancellationToken);

        return entity is null ? Unit.Value : entity;
    }

    public async Task<OneOf<TEntity, Unit>> FindOneAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Set<TEntity>()
            .FirstOrDefaultAsync(specification.Criteria, cancellationToken);

        return entity is null ? Unit.Value : entity;
    }

    public async Task<OneOf<IEnumerable<TEntity>>> FindManyAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        var entities = await _context.Set<TEntity>()
            .Where(specification.Criteria)
            .ToArrayAsync(cancellationToken);

        return entities;
    }
}
