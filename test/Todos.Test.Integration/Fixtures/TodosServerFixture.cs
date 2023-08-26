using Microsoft.AspNetCore.Mvc.Testing;

namespace Todos.Test.Integration.Fixtures;

public class TodosServerFixture : WebApplicationFactory<Todos.Server.Program>
{
}
