namespace Todos.Core.Abstractions;

public interface ISpecification<T>
{
    public Expression<Func<T, bool>> Expression { get; }

    public bool IsSatisfied(T candidate);

    public ISpecification<T> Not();

    public ISpecification<T> And(ISpecification<T> right);

    public ISpecification<T> AndNot(ISpecification<T> right);

    public ISpecification<T> Or(ISpecification<T> right);

    public ISpecification<T> OrNot(ISpecification<T> right);
}
