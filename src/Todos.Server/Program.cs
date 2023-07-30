using Todos.Infra.Extensions;
using Todos.Infra.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTodosInfra(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
