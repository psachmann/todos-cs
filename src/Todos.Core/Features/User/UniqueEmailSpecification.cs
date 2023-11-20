using Todos.Core.Specifications;

namespace Todos.Core.Features.User;

public sealed class UniqueEmailSpecification(string email) : SpecificationBase<UserEntity>
{
    public override Expression<Func<UserEntity, bool>> Criteria => (candidate) => candidate.Email != email;

    public override bool IsSatisfied(UserEntity candidate)
    {
        return candidate.Email != email;
    }

}
