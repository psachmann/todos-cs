using Todos.Infra.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTodosInfra(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
