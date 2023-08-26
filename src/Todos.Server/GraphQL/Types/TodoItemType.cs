namespace Todos.Server.GraphQL.Types;

public sealed class TodoItemType : ObjectType<TodoItemEntity>
{
    protected override void Configure(IObjectTypeDescriptor<TodoItemEntity> descriptor)
    {
        descriptor.Name(SchemaUtils.GetEntityQueryName<TodoItemEntity>());
    }
}

