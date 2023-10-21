using Todos.Infra.Behaviors;
using Todos.Infra.Data;

namespace Todos.Infra.Extensions;

public static class ServiceCollectionTodosExtensions
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
            .AddTodosOptions(configuration)
            .AddTodosContext(configuration)
            .AddTodosServices();

    private static IServiceCollection AddTodosContext(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddDbContext<TodosContext>(builder =>
            {
                builder.UseInMemoryDatabase("TodosContext");
                // builder.UseNpgsql(configuration.GetConnectionString("postgres"));
            });


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

    public static IServiceCollection AddTodosOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<DatabaseOptions>()
            .Bind(configuration.GetSection(DatabaseOptions.SectionName))
            .ValidateFluently()
            .ValidateOnStart();

        return services;
    }
}
