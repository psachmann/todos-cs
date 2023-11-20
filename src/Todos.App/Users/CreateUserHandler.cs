using Todos.Core.Features.User;

namespace Todos.App.Users;

internal sealed class CreateUserHandler(IEntityReader<UserEntity> reader, IEntityWriter<UserEntity> writer, IMapper mapper)
    : IRequestHandler<CreateUserCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var user = mapper.Map<UserEntity>(command);
        var result = await reader.FindOneAsync(new UniqueEmailSpecification(command.Email), cancellationToken);

        if (result.IsT0)
        {
            // TODO: throw a custom domain exception
            throw new Exception();
        }

        var userId = await writer.CreateOneAsync(user, cancellationToken);

        return userId;
    }
}
