namespace Todos.Infra.Data;

internal sealed class EntityReaderImpl<TEntity> : IEntityReader<TEntity>, ITransientMarker
    where TEntity : class, IEntity
{
    private readonly TodosContext _context;

    public EntityReaderImpl(TodosContext context)
    {
        _context = context;
    }

    public async Task<OneOf<TEntity, Unit>> FindByIdAsync(Guid id)
    {
        var entity = await _context.Set<TEntity>()
            .FindAsync(id);

        return entity is null ? Unit.Value : entity;
    }

    public async Task<OneOf<TEntity, Unit>> FindOneAsync(ISpecification<TEntity> specification)
    {
        var entity = await _context.Set<TEntity>()
            .FirstOrDefaultAsync(specification.Expression);

        return entity is null ? Unit.Value : entity;
    }

    public async Task<OneOf<IEnumerable<TEntity>>> FindManyAsync(ISpecification<TEntity> specification)
    {
        var entities = await _context.Set<TEntity>()
            .Where(specification.Expression)
            .ToArrayAsync();

        return entities;
    }
}
