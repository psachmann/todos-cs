namespace Todos.Core.Specifications;

public sealed class FindAllSpecification<TEntity> : SpecificationBase<TEntity>
    where TEntity : class, IEntity
{
    public override Expression<Func<TEntity, bool>> Criteria => (_) => true;

    public override bool IsSatisfied(TEntity candidate) => true;
}
