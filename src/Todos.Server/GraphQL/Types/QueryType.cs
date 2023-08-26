namespace Todos.Server.GraphQL.Types;

public sealed class QueryType : ObjectType<Query>
{
    protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
    {
        descriptor.Field((query) => query.GetAllTodoItemsAsync(default!, default))
            .Type<ListType<TodoItemType>>();

        descriptor.Field((query) => query.GetTodoItemAsync(default!, default!, default))
            .Type<TodoItemType>();

        descriptor.Field((query) => query.GetTodoListAsync(default!, default!, default))
            .Type<TodoListType>();
    }
}
