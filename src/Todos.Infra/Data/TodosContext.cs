using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Todos.Infra.Data;

internal sealed class TodosContext : DbContext
{
    private readonly DatabaseOptions _options;


    public TodosContext(DatabaseOptions options)
    {
        _options = options;
    }

    public TodoItemEntity? TodoItems { get; init; }

    public TodoListEntity? TodoLists { get; init; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(_options.Connection, new MySqlServerVersion(_options.Version));
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(LibTodosInfra.Assembly);
    }
}
