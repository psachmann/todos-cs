using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Todos.Infra.Data.Configurations;

internal sealed class TodoListConfiguration : ConfigurationBase<TodoListEntity>
{
    public override string TableName => "todo_lists";

    public override void Configure(EntityTypeBuilder<TodoListEntity> builder)
    {
        base.Configure(builder);

        builder.Property(todoList => todoList.Title)
            .IsRequired()
            .HasMaxLength(CreateTodoListValidator.MaxTitleLength);

        builder.HasMany(todoList => todoList.Items)
            .WithOne();
    }
}
