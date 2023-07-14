namespace Todos.Infra.Data;

internal sealed class EntityWriterImpl<TEntity> : IEntityWriter<TEntity>, ITransientMarker
    where TEntity : class, IEntity
{
    private readonly TodosContext _context;

    public EntityWriterImpl(TodosContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateOneAsync(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<IEnumerable<Guid>> CreateManyAsync(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().AddRange(entities);
        await _context.SaveChangesAsync();

        return entities.Select(entity => entity.Id).ToArray();
    }

    public async Task UpdateOneAsync(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateManyAsync(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().UpdateRange(entities);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteOneAsync(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteManyAsync(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().RemoveRange(entities);
        await _context.SaveChangesAsync();
    }
}
