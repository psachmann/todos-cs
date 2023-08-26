namespace Todos.Server.GraphQL.Types;

public sealed class MutationType : ObjectType<Mutation>
{
    protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
    {
        descriptor.Field((mutation) => mutation.CreateTodoItemAsync(default!, default!, default));

        descriptor.Field((mutation) => mutation.UpdateTodoItemAsync(default!, default!, default));

        descriptor.Field((mutation) => mutation.DeleteTodoItemAsync(default!, default!, default));
    }
}
