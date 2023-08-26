namespace Todos.Server.GraphQL.Types;

public sealed class TodoListType : ObjectType<TodoListEntity>
{
    protected override void Configure(IObjectTypeDescriptor<TodoListEntity> descriptor)
    {
        descriptor.Name(SchemaUtils.GetEntityQueryName<TodoListEntity>());
    }
}
