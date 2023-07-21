namespace Todos.Core.Specifications;

public class FindByEmailSpecification : SpecificationBase<UserEntity>
{
    private readonly string _email;

    public FindByEmailSpecification(string email)
    {
        Func<UserEntity, bool> predicate = (user) => user.Email == email;
        _email = email;
    }

    public override Expression<Func<UserEntity, bool>> Criteria => (user) => _email == user.Email;

    public override bool IsSatisfied(UserEntity candidate)
    {
        return _email == candidate.Email;
    }
}
