using Todos.Infra.Behaviors;

namespace Todos.Infra.Extensions;

public static class ServiceCollectionExtensions
{
    private static readonly Assembly[] AssembliesToScan = new[] { LibTodosCore.Assembly, LibTodosInfra.Assembly };

    public static IServiceCollection AddTodosInfra(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddAutoMapper(AssembliesToScan)
            .AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(AssembliesToScan);
                config.AddOpenBehavior(typeof(LoggingBehavior<,>));
                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            })
            .AddValidatorsFromAssemblies(AssembliesToScan)
            .AddTodosContext(configuration)
            .AddTodosServices();

    private static IServiceCollection AddTodosContext(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddDbContext<TodosContext>();

    private static IServiceCollection AddTodosServices(this IServiceCollection services)
        => services
            .Scan(scan => scan
                .FromAssemblies(AssembliesToScan)
                .AddClasses(classes => classes.AssignableTo<ITransient>())
                    .AsImplementedInterfaces()
                    .WithTransientLifetime()
                .AddClasses(classes => classes.AssignableTo<IScoped>())
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
                .AddClasses(classes => classes.AssignableTo<ISingleton>())
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime());
}


