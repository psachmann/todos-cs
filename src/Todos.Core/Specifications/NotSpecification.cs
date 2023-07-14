namespace Todos.Core.Specifications;

public class NotSpecification<T> : SpecificationBase<T>
{
    private readonly ISpecification<T> _specification;

    public NotSpecification(ISpecification<T> specification)
    {
        _specification = specification;
    }

    public override bool IsSatisfied(T candidate)
    {
        return !_specification.IsSatisfied(candidate);
    }
}
