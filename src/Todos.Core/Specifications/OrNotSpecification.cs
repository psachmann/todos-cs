namespace Todos.Core.Specifications;

public class OrNotSpecification<T> : SpecificationBase<T>
{
    private readonly ISpecification<T> _left;
    private readonly ISpecification<T> _right;

    public OrNotSpecification(ISpecification<T> left, ISpecification<T> right)
    {
        _left = left;
        _right = right;
    }

    public override Expression<Func<T, bool>> Criteria
    {
        get
        {
            var param = _left.Criteria.Parameters.First();
            var orNot = Expression.AndAlso(_left.Criteria.Body, Expression.Not(_right.Criteria.Body));
            return Expression.Lambda<Func<T, bool>>(orNot, param);
        }
    }

    public override bool IsSatisfied(T candidate)
    {
        return _left.IsSatisfied(candidate) || !_right.IsSatisfied(candidate);
    }
}
