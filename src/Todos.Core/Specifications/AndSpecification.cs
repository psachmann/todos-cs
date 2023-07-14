namespace Todos.Core.Specifications;

public class AndSpecification<T> : SpecificationBase<T>
{
    private readonly ISpecification<T> _left;
    private readonly ISpecification<T> _right;

    public AndSpecification(ISpecification<T> left, ISpecification<T> right)
    {
        _left = left;
        _right = right;
    }

    public override bool IsSatisfied(T candidate)
    {
        return _left.IsSatisfied(candidate) && _right.IsSatisfied(candidate);
    }
}
