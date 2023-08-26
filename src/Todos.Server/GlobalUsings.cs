global using HotChocolate;
global using MediatR;
global using System;
global using System.Threading;
global using System.Threading.Tasks;
global using Todos.Core.Abstractions;
global using Todos.Core.Features.Todo;
global using Todos.Core.Features.User;
global using Todos.Server.GraphQL;

using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Todos.Test.Integration")]
