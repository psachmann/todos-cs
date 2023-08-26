using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Todos.Infra.Data.Configurations;

internal sealed class TodoItemConfiguration : ConfigurationBase<TodoItemEntity>
{
    public override string TableName => "todo_items";

    public override void Configure(EntityTypeBuilder<TodoItemEntity> builder)
    {
        base.Configure(builder);

        builder.Property(todoItem => todoItem.Title)
            .IsRequired()
            .HasMaxLength(CreateTodoItemValidator.MaxTitleLength);

        builder.Property(todoItem => todoItem.Description)
            .IsRequired()
            .HasMaxLength(CreateTodoItemValidator.MaxDescriptionLength);

        builder.Property(todoItem => todoItem.IsDone)
            .IsRequired();
    }
}
