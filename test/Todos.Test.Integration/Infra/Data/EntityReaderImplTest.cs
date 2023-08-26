using Todos.Core.Abstractions;
using Todos.Core.Features.Todo;

namespace Todos.Test.Integration.Infra.Data;

public class EntityReaderImplTest : IClassFixture<TodosServerFactory>
{
    private readonly IEntityReader<TodoItemEntity> _sut;

    public EntityReaderImplTest(TodosServerFactory factory)
    {
        _sut = factory.Services.GetRequiredService<IEntityReader<TodoItemEntity>>();
    }
}
