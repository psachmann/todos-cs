namespace Todos.Core.Specifications;

public class NotSpecification<T> : SpecificationBase<T>
{
    private readonly ISpecification<T> _specification;

    public NotSpecification(ISpecification<T> specification)
    {
        _specification = specification;
    }

    public override Expression<Func<T, bool>> Criteria
    {
        get
        {
            var param = _specification.Criteria.Parameters.First();
            var not = Expression.Not(_specification.Criteria.Body);
            return Expression.Lambda<Func<T, bool>>(not, param);
        }
    }

    public override bool IsSatisfied(T candidate)
    {
        return !_specification.IsSatisfied(candidate);
    }
}
