namespace Todos.Core.Specifications;

public abstract class SpecificationBase<T> : ISpecification<T>
{
    public abstract bool IsSatisfied(T candidate);

    public ISpecification<T> Not()
    {
        return new NotSpecification<T>(this);
    }

    public ISpecification<T> And(ISpecification<T> right)
    {
        return new AndSpecification<T>(this, right);
    }

    public ISpecification<T> AndNot(ISpecification<T> right)
    {
        return new AndNotSpecification<T>(this, right);
    }

    public ISpecification<T> Or(ISpecification<T> right)
    {
        return new OrSpecification<T>(this, right);
    }

    public ISpecification<T> OrNot(ISpecification<T> right)
    {
        return new OrNotSpecification<T>(this, right);
    }
}
