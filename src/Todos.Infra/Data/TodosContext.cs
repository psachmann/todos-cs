namespace Todos.Infra.Data;

internal sealed class TodosContext : DbContext
{
    public TodosContext(DbContextOptions<TodosContext> options)
        : base(options)
    {
    }

    public TodoItemEntity? TodoItems { get; init; }

    public TodoListEntity? TodoLists { get; init; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(AssemblyInfo.Assembly);
    }
}
