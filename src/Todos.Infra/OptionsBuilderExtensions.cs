namespace Todos.Infra.Extensions;

internal static class OptionsBuilderExtensions
{
    public static OptionsBuilder<TOptions> ValidateFluently<TOptions>(this OptionsBuilder<TOptions> builder)
        where TOptions : class
    {
        builder.Services.AddSingleton<IValidateOptions<TOptions>>((serviceProvider) =>
            new FluentValidationOptions<TOptions>(builder.Name, serviceProvider.GetRequiredService<IValidator<TOptions>>()));
        return builder;
    }
}
