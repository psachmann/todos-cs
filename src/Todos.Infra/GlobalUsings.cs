global using AutoMapper;
global using FluentValidation;
global using MediatR;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.Configuration.Json;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;
global using OneOf;
global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Reflection;
global using System.Threading;
global using System.Threading.Tasks;
global using Todos.Core;
global using Todos.Core.Abstractions;
global using Todos.Core.Exceptions;
global using Todos.Core.Features.Todo;
global using Todos.Core.Features.User;
global using Todos.Infra.Options;
global using static Todos.Core.Constants;

using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Todos.Test.Unit")]
